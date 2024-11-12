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
     
     // Mevcut Task tamamlandi, kendisinden sonra calismasi gereken Task tanimlanmis mi ? 
     if (jobName == nameof(DbUpdateTask))
     {
         await _scheduler.TriggerJob(new JobKey(nameof(ElastichIndexUpdateTask)), cancellationToken);
     }
     else if (jobName == nameof(ElastichIndexUpdateTask))
     {
         await _scheduler.TriggerJob(new JobKey(nameof(IliskiTask)), cancellationToken);
     }
     else if (jobName == nameof(IliskiTask))
     {
         Console.WriteLine($"Tüm işler başarıyla tamamlandı.{DateTime.Now}\n\n");

     }
            }
            else
            {
                Console.WriteLine($"{jobName} sırasında hata oluştu: {jobException.Message}");
            }
        }
    }

}
