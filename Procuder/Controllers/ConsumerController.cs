namespace ChannelApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumerController : ControllerBase
{
    private readonly ChannelService _channelService;
    public ConsumerController(ChannelService channelService)
    {
        _channelService = channelService;
    }
    [HttpPost(Name = "GetData")]
    public IActionResult Get()
    {
        return Ok(_channelService._ConsumedMessage);
    }
}
