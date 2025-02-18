namespace ChannelApi.Services;

public class ConsumerService : BackgroundService
{
    private readonly ChannelService _channelService;

    public ConsumerService(ChannelService channelService)
    {
        _channelService = channelService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var json in _channelService._Channel.Reader.ReadAllAsync(stoppingToken))
        {
            var data = JsonSerializer.Deserialize<Message>(json);
            _channelService._ConsumedMessage.Enqueue(data);
            Console.WriteLine($"Consumed: Id={data.Id}, Message={data.Text}");
        }
    }

}
