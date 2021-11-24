using ProtoBuf.Grpc.Client;
using Grpc.Net.Client;
using PiClientApi;
using PiClient;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        // Add services to the container.


        services.AddSingleton(sc =>
        {
            // Get the service address from appsettings.json
            var config = sc.GetRequiredService<IConfiguration>();
            var baseUrl = config["ServerBaseUri"];

            return GrpcChannel.ForAddress(baseUrl);
        });
        services.AddSingleton(sc =>
        {
            var srv = (sc.GetService<GrpcChannel>() ?? throw new InvalidOperationException())
                .CreateGrpcService<IPiMessagesReciever>();
            return srv;
        });

    })
    .Build();

await host.RunAsync();

