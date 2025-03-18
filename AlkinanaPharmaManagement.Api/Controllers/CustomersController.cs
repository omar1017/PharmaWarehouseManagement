using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Application.Customers.Create;
using AlkinanaPharmaManagment.Application.Customers.Delete;
using AlkinanaPharmaManagment.Application.Customers.GetById;
using AlkinanaPharmaManagment.Application.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagement.Api.Controllers
{
    //[Authorize(Roles ="Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISender sender;

        public CustomersController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerRequest request) =>
             CreatedAtAction(nameof(CreateCustomer),new {customerId = await sender.Send(new CreateCustomerCommand(request)) });


        [Authorize(Roles = "Administrator")]
        [HttpGet("carts")]
        public async Task<IActionResult> GetCarts([FromQuery] CartSearchRequest request) => 
            Ok(await sender.Send(new GetCartsQuery(request)));

        [Authorize(Roles = "Administrator")]
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId) => 
            Ok( await sender.Send(new GetCustomerByIdQuery(customerId)));

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
            await sender.Send(new DeleteCustomerCommand(customerId));
            return NoContent();
        }

    }
}
