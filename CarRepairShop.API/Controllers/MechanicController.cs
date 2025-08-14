using CarRepairShop.Application.Commands.Mechanic;
using CarRepairShop.Application.DTOs.Mechanic;
using CarRepairShop.Application.Queries.Mechanic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MechanicController : Controller
{
    private readonly IMediator _mediator;

    public MechanicController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MechanicDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var mechanics = await _mediator.Send(new GetAllMechanicsQuery());
        return Ok(mechanics);
    }

    [HttpGet]
    [ProducesResponseType(typeof(MechanicDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid mechanicId)
    {
        var mechanic = await _mediator.Send(new GetMechanicByIdQuery(mechanicId));
        return mechanic.Id == Guid.Empty ? NotFound() : Ok(mechanic);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(MechanicCreateDto mechanic)
    {
        var newId = await _mediator.Send(new CreateMechanicCommand(mechanic));
        return Ok(newId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(MechanicUpdateDto mechanic)
    {
        await _mediator.Send(new UpdateMechanicCommand(mechanic));
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(MechanicDeleteDto mechanic)
    {
        await _mediator.Send(new DeleteMechanicCommand(mechanic));
        return Ok();
    }
}