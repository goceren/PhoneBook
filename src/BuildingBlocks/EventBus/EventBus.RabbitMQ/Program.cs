using EventBus.Business.Abstract;
using EventBus.Business.Concrete;
using EventBus.RabbitMQ;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddSingleton(configuration);
        services.AddTransient<IReportQService, ReportQService>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
