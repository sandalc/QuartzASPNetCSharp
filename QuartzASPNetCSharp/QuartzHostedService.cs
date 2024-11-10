namespace QuartzJobListenerAndChaining
{

    using Microsoft.Extensions.Hosting;
    using Quartz;
    using Quartz.Spi;
    using System.Threading;
    using System.Threading.Tasks;
    using static Quartz.Logging.OperationName;

    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler = null!;

        public QuartzHostedService(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);

            if (_scheduler == null)
            {
                throw new InvalidOperationException("Scheduler başarıyla başlatılamadı.");
            }

            // CustomJobListener'ı scheduler'a ekleme
            _scheduler.ListenerManager.AddJobListener(new CustomJobListener(_scheduler));

            // İşleri oluşturma
            var DbUpdateTask = JobBuilder.Create<DbUpdateTask>().
                                            WithIdentity("DbUpdateTask").Build();

            var ElastichIndexUpdateTask = JobBuilder.Create<ElastichIndexUpdateTask>().
                                            WithIdentity("ElastichIndexUpdateTask").StoreDurably().Build();

            var IliskiTask = JobBuilder.Create<IliskiTask>().WithIdentity("IliskiTask").StoreDurably().Build();


            //// Trigger'ı her 1 dakikada bir çalışacak şekilde yapılandırıyoruz
            var triggerDbUpdateTask = TriggerBuilder.Create()
                .WithIdentity("DbUpdateTaskA")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInMinutes(1)    // 1 dakika arayla tetiklenecek
                .RepeatForever())            // Sonsuz kez tekrar edecek
                .Build();

            // CronExpression kullanarak job'ı belirli saatlerde çalışacak şekilde ayarlıyoruz
            //var cronExpression = "0 0 9,18 * * ?";  // Her gün 09:00 ve 18:00'de tetiklenecek
            //var triggerDbUpdateTask = TriggerBuilder.Create()
            //    .WithIdentity("DbUpdateTaskA")
            //    .WithCronSchedule(cronExpression) // CronExpression ile zamanlama
            //    .Build();

            await _scheduler.ScheduleJob(DbUpdateTask, triggerDbUpdateTask, cancellationToken);
            await _scheduler.AddJob(ElastichIndexUpdateTask, replace: true, cancellationToken);
            await _scheduler.AddJob(IliskiTask, replace: true, cancellationToken);
            await _scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_scheduler != null)
            {
                await _scheduler.Shutdown(cancellationToken);
            }

        }
    }
}
