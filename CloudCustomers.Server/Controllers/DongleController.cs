using CloudCustomers.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.Server.Controllers;

[Authorize]
[ApiController]
[Route("api/dongle/")]
public class DongleController : ControllerBase
{
    private readonly IDongleService _dongleService;

    public DongleController()
    {
    }

    public DongleController(IDongleService dongleService)
    {
        _dongleService = dongleService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDongles()
    {
        var dongles = await _dongleService.GetAllDongles();
        if (dongles != null && dongles.Any()) return Ok(dongles);
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDongleBySerial(string serial)
    {
        var dongle = await _dongleService.GetDongleById(serial);
        var dongleSerial = dongle.SerialNumber;
        if (string.IsNullOrEmpty(dongleSerial))    return NotFound();
        return Ok(dongle);
    }
}