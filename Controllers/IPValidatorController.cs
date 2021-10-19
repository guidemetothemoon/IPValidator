using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

[Route("")]
public class RequestValidatorController : ControllerBase
{
    
    private readonly ILogger<RequestValidatorController> _logger;

    public RequestValidatorController(ILogger<RequestValidatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public string RequestIp()
    {
        var currentIp = HttpContext.Connection.RemoteIpAddress;
        string headerIp = (HttpContext.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault()) ?? "None";
        
        if (currentIp != null && currentIp.IsIPv4MappedToIPv6)
        {
            currentIp.MapToIPv4();
        }
        return $"RemoteIpAddress: {currentIp}, IP from request header: {headerIp}";
    }
}
