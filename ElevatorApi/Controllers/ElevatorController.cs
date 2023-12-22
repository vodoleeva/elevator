using Microsoft.AspNetCore.Mvc;
using ElevatorApp.DTO;
using ElevatorApp.Services;

namespace ElevatorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ElevatorController
{
    private readonly ElevatorService _elevatorService;
    
    public ElevatorController(ElevatorService elevatorService)
    {
        _elevatorService = elevatorService;
    }
    
    // [HttpGet]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [Route("elevators")]
    // public ActionResult<IEnumerable<ElevatorRecord>
}
