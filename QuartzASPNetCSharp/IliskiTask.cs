namespace QuartzJobListenerAndChaining
{
    using Quartz;
    using System;
    using System.Threading.Tasks;

    public class IliskiTask : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"IliskiTask çalışıyor: {DateTime.Now}");
            await Task.Delay(3000); //  3 saniye bekleme süresi
        }
    }


}
