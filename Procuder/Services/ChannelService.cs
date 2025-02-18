namespace ChannelApi.Services;

public class ChannelService
{
    public readonly ConcurrentQueue<Message> _ConsumedMessage = new();
    public Channel<string> _Channel { get; } = Channel.CreateUnbounded<string>();
}
