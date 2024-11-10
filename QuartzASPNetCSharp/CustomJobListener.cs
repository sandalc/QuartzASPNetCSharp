namespace QuartzJobListenerAndChaining
{
    using Quartz;
    using System.Threading;
    using System.Threading.Tasks;

    public class CustomJobListener : IJobListener
    {
        private readonly IScheduler _scheduler;

        public CustomJobListener(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public string Name => "CustomJobListener";

        public Task JobToBeExecuted(IJobExecutionContext context)
        {
            Console.WriteLine($"{context.JobDetail.Key.Name} başlamak üzere.");
            return Task.CompletedTask;
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{context.JobDetail.Key.Name} başlamak üzere.");
            return Task.CompletedTask;
        }

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{context.JobDetail.Key.Name} iptal edildi.");
            return Task.CompletedTask;
        }

         async public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException, CancellationToken cancellationToken = default)
        {
            var jobName = context.JobDetail.Key.Name;

            if (jobException == null)
            {
                Console.WriteLine($"{jobName} başarıyla tamamlandı. {DateTime.Now}");
                if (jobName == "DbUpdateTask")
                {
                    await _scheduler.TriggerJob(new JobKey("ElastichIndexUpdateTask"), cancellationToken);
                }
                else if (jobName == "ElastichIndexUpdateTask")
                {
                    await _scheduler.TriggerJob(new JobKey("IliskiTask"), cancellationToken);
                }
                else if (jobName == "IliskiTask")
                {
                    Console.WriteLine($"Tüm işler başarıyla tamamlandı.{DateTime.Now}");

                }
            }
            else
            {
                Console.WriteLine($"{jobName} sırasında hata oluştu: {jobException.Message}");
            }
        }
    }

}