using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestUserController : ControllerBase
{

    public TestUserController()
    {
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        return Ok("That is nice");
    }
}
