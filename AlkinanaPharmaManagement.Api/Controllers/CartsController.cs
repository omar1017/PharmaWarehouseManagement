using AlkinanaPharmaManagment.Application.Carts;
using AlkinanaPharmaManagment.Application.Carts.Delete;
using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Application.Carts.GetById;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
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
    public class CartsController : ControllerBase
    {
        private readonly ISender sender;

        public CartsController(ISender sender)
        {
            this.sender = sender;
        }


        

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCart(Guid Id) => Ok(await sender.Send(new GetCartByIdQuery(Id)));


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateCart(CartRequest cart) => CreatedAtAction(nameof(GetCart),
            new { Id = await sender.Send(new CreateCartCommand(cart)) });

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCart(CartId cartId)
        {
            await sender.Send(new DeleteCartCommand(cartId));
            return NoContent();
        }


    }
}
