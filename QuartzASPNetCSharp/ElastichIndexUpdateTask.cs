namespace QuartzJobListenerAndChaining
{
    using Quartz;
    using System;
    using System.Threading.Tasks;

    public class ElastichIndexUpdateTask : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"ElastichIndexUpdateTask çalışıyor: {DateTime.Now}");
            await Task.Delay(2500); // 2,5 saniye bekleme süresi
        }
    }


}
