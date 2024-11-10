namespace QuartzJobListenerAndChaining
{
    using Quartz;
    using System;
    using System.Threading.Tasks;

    public class DbUpdateTask : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"DbUpdateTask çalışıyor: {DateTime.Now}");
            await Task.Delay(4000); // 4 saniye bekleme süresi
        }
    }


}
