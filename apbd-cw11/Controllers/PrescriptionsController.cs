using apbd_cw11.DTOs;
using apbd_cw11.Exceptions;
using apbd_cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw11.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddPrescriptionDTO dto)
    {
        try
        {
            var newId = await _dbService.AddPrescriptionAsync(dto);
            return CreatedAtAction(
                nameof(PatientsController.GetPatient),
                controllerName: "Patients",
                new { idPatient = dto.Patient.IdPatient },
                new { idPrescription = newId });
        }
        catch (InvalidPrescriptionException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}