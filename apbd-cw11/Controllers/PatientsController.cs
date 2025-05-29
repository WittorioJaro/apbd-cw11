using apbd_cw11.Exceptions;
using apbd_cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatient(int idPatient)
    {
        try
        {
            var patient = await _dbService.GetPatientAsync(idPatient);
            return Ok(patient);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Wystąpił nieoczekiwany błąd." });
        }
    }
}