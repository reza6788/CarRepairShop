using CarRepairShop.Application.Commands.Customer;
using CarRepairShop.Application.DTOs.Customer;
using CarRepairShop.Application.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerController : Controller
{
   private readonly IMediator _mediator;

   public CustomerController(IMediator mediator)
   {
      _mediator = mediator;
   }
   
   [HttpGet]
   [ProducesResponseType(typeof(IEnumerable<CustomerDto>), StatusCodes.Status200OK)]
   public async Task<IActionResult> GetAll()
   {
      var customers = await _mediator.Send(new GetAllCustomersQuery());
      return Ok(customers);
   }

   [HttpGet]
   [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
   public async Task<IActionResult> GetById(Guid customerId)
   {
      var customer = await _mediator.Send(new GetCustomerByIdQuery(customerId));
      return customer.Id == Guid.Empty ? NotFound() : Ok(customer);
   }

   [HttpPost]
   [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
   public async Task<IActionResult> Create(CustomerCreateDto customer)
   {
      var newId = await _mediator.Send(new CreateCustomerCommand(customer));
      return Ok(newId);
   }

   [HttpPut]
   [ProducesResponseType(StatusCodes.Status200OK)]
   public async Task<IActionResult> Update(CustomerUpdateDto customer)
   {
      await _mediator.Send(new UpdateCustomerCommand(customer));
      return Ok();
   }

   [HttpDelete]
   [ProducesResponseType(StatusCodes.Status200OK)]
   public async Task<IActionResult> Delete(CustomerDeleteDto customer)
   {
      await _mediator.Send(new DeleteCustomerCommand(customer));
      return Ok();
   }
}