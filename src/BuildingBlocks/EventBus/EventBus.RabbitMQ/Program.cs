using EventBus.RabbitMQ;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddSingleton(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
