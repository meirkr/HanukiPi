using PiClientApi;


namespace PiClient;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IPiMessagesReciever _piMessagesReciever;

    public Worker(ILogger<Worker> logger, IPiMessagesReciever piMessagesReciever)
    {
        _logger = logger;
        _piMessagesReciever = piMessagesReciever;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var asyncCommands = _piMessagesReciever.GetCommandsAsync();
        await foreach (var command in asyncCommands)
        {
            _logger.LogInformation("Command arrived: {time}. Op ,mode:{OperationMode}, leds Count: {LedsCount}", 
                DateTimeOffset.Now, 
                command.operationMode, 
                command.NineLeds?.Length);

        }
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
