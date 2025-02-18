namespace ChannelApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProducerController : ControllerBase
{
    private readonly ChannelService _channelService;
    public ProducerController(ChannelService channelService)
    {
        _channelService = channelService;
    }

    [HttpPost(Name = "PostData")]
    public async Task<IActionResult> Post([FromBody] Message _message)
    {
        var jsonData = JsonSerializer.Serialize(_message);
        await _channelService._Channel.Writer.WriteAsync(jsonData);
        return Ok(new { message = "Data added to channel", _message });
    }
}
