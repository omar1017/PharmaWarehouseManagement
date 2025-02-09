using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Application.Customers.Create;
using AlkinanaPharmaManagment.Application.Customers.Delete;
using AlkinanaPharmaManagment.Application.Customers.Get;
using AlkinanaPharmaManagment.Application.Customers.GetByCity;
using AlkinanaPharmaManagment.Application.Customers.GetById;
using AlkinanaPharmaManagment.Application.Customers.GetByName;
using AlkinanaPharmaManagment.Application.Customers.GetByPharma;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        

        [HttpGet("{customerId}/carts")]
        public async Task<IActionResult> GetCarts(Guid customerId) => Ok(await sender.Send(new GetCartsQuery(customerId)));

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId) => Ok( await sender.Send(new GetCustomerByIdQuery(customerId)));

        [HttpGet("city/{cityName}")]
        public async Task<IActionResult> GetCustomerByCity(string cityName) => Ok(await sender.Send(new GetCustomerByCityQuery(cityName)));

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCustomerByName(string name) => Ok(await sender.Send(new GetCustomerByNameQuery(name)));

        [HttpGet("pharma/{pharmaName}")]
        public async Task<IActionResult> GetCustomerByPharma(string pharmaName) => Ok(await sender.Send(new GetCustomersByPharmaQuery(pharmaName)));

       
            

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
            await sender.Send(new DeleteCustomerCommand(customerId));
            return NoContent();
        }

    }
}
