using System.ComponentModel;
using CloudCustomers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[ApiController]
[Route("api/license/")]
public class LicenseController : ControllerBase
{
    private readonly ILicensesService _licensesService;

    public LicenseController()
    {
        
    }
    public LicenseController(ILicensesService licensesService)
    {
        _licensesService = licensesService;
    }

    [HttpGet(Name = "get-licenses")]
    public async Task<IActionResult> GetAllLicense()
    {
        var licenses = await _licensesService.GetAllLicenses();
        if (licenses.Any())  return Ok(licenses);
        return NotFound();
    }
}
