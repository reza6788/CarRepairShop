using CarRepairShop.Application.Commands.RepairOrder;
using CarRepairShop.Application.DTOs.RepairOrder;
using CarRepairShop.Application.Queries.RepairOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RepairOrderController : Controller
{
    private readonly IMediator _mediator;

    public RepairOrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RepairOrderDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllRepairOrder()
    {
        var repairOrders = await _mediator.Send(new GetAllRepairOrdersQuery());
        return Ok(repairOrders);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RepairOrderDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOpenRepairOrders()
    {
        var repairOrders = await _mediator.Send(new GetOpenRepairOrdersQuery());
        return Ok(repairOrders);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(RepairOrderDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid orderId)
    {
        var repairOrder = await _mediator.Send(new GetRepairOrderByIdQuery(orderId));
        return repairOrder.Id == Guid.Empty ? NotFound() : Ok(repairOrder);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(RepairOrderDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByVehicleId(Guid vehicleId)
    {
        var repairOrderDto = await _mediator.Send(new GetRepairOrderByVehicleIdQuery(vehicleId));
        return Ok(repairOrderDto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateRepairOrder(CreateRepairOrderDto command)
    {
        var id = await _mediator.Send(new CreateRepairOrderCommand(command));
        return CreatedAtAction(nameof(CreateRepairOrder), new { id }, id);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AssignMechanic(Guid repairOrderId, Guid mechanicId)
    {
        await _mediator.Send(new AssignMechanicCommand(repairOrderId,mechanicId));
        return Ok();
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CompleteRepairOrder(Guid repairOrderId)
    {
        await _mediator.Send(new CompleteRepairOrderCommand(repairOrderId));
        return Ok();
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateRepairOrder(UpdateRepairOrderDto command)
    {
        await _mediator.Send(new UpdateRepairOrderCommand(command));
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteRepairOrder(DeleteRepairOrderDto command)
    {
        await _mediator.Send(new DeleteRepairOrderCommand(command));
        return Ok();
    }
}