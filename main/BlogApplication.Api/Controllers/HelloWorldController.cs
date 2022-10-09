using BlogApplication.Domain.interfaces;
using BlogApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class HelloWorldController : ControllerBase
{
    private readonly IHelloWorldService _helloWorldService;
    private readonly IPost _postService;
    private readonly ILogger<HelloWorldController> _logger;
    
    public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger,
        IPost post)
    {
        _postService = post;
        _logger = logger;
        _helloWorldService = helloWorldService;
    }
    
    [HttpGet]
    public async Task<OkObjectResult> Get()
    {
        await _postService.SavePost();
        //_logger.LogInformation("Se entra al endpoint Get");
        _logger.LogDebug("Se entra al endpoint Get");
        return Ok(_helloWorldService.GetHelloWorld());
    }
}