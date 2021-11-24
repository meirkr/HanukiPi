using ProtoBuf.Grpc.Server;
using WebServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

ConfigureServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PiRemoteSerice>()
    .EnableGrpcWeb();




app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();



//////////////////////////////////////////////////////

void ConfigureServices(IServiceCollection services)
{
    // Add services to the container.
    services.AddCodeFirstGrpc();


}
