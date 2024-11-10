using Quartz.Impl;
using Quartz;
using QuartzJobListenerAndChaining;
using static Quartz.Logging.OperationName;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        /* Projede Quartz.NET kullanarak i?lerin s?ral? çal??mas?n? sa?lamak için 
           bir ASP.NET Core uygulamas? olu?turduk. 
           Projede üç farkl? i?(DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) s?ras?yla çal??t?r?l?yor
                  
           JobListener ve chaining (zincirleme) kombinasyonu kullan?r. 
           ??ler s?ral? ?ekilde çal??t?r?lacak, 
           ayn? zamanda her i?in ba?lang?ç, tamamlanma ve hata durumlar? JobListener ile izlenip loglanacak (Console).

           E?er Quartz.NET ile belirli bir aral?kla (örne?in her 3 saatte bir) bir i?in tetiklenmesini istiyorsan?z, 
           bunun için bir zamanlay?c? (trigger) olu?turman?z gerekecek. 
           Bu zamanlay?c?y?, TriggerBuilder kullanarak belirli bir aral?kta çal??acak ?ekilde yap?land?rabilirsiniz

        */

        // Add services to the container.
        IServiceCollection serviceCollection = builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
        IServiceCollection serviceCollection1 = builder.Services.AddHostedService<QuartzHostedService>();
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}