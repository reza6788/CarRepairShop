using CarRepairShop.Application.Commands.Vehicle;
using CarRepairShop.Application.DTOs.Vehicle;
using CarRepairShop.Application.Queries.Vehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class VehicleController : Controller
{
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VehicleDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _mediator.Send(new GetAllVehiclesQuery());
        return Ok(vehicles);
    }

    [HttpGet]
    [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid vehicleId)
    {
        var vehicle = await _mediator.Send(new GetVehicleByIdQuery(vehicleId));
        return vehicle.Id == Guid.Empty ? NotFound() : Ok(vehicle);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(VehicleCreateDto vehicle)
    {
        var newId = await _mediator.Send(new CreateVehicleCommand(vehicle));
        return Ok(newId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(VehicleUpdateDto vehicle)
    {
        await _mediator.Send(new UpdateVehicleCommand(vehicle));
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(VehicleDeleteDto vehicle)
    {
        await _mediator.Send(new DeleteVehicleCommand(vehicle));
        return Ok();
    }
}