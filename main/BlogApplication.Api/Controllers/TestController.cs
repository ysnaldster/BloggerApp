
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Api.Controllers;


[ApiController]
[Route("[controller]/api")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult SetTest()
    {
        return Ok("Llego");
    }
    
}