using Quartz.Impl;
using Quartz;
using QuartzJobListenerAndChaining;
using static Quartz.Logging.OperationName;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
     
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
