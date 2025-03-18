using AlkinanaPharmaManagment.Application.Carts;
using AlkinanaPharmaManagment.Application.Carts.Active;
using AlkinanaPharmaManagment.Application.Carts.Delete;
using AlkinanaPharmaManagment.Application.Carts.GetById;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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



        [Authorize(Roles = "Administrator")]
        [HttpGet("{CartId}")]
        public async Task<IActionResult> GetCart(Guid CartId) =>
    Ok(await sender.Send(new GetCartByIdQuery(new CartId(CartId))));


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateCart(CartRequest cart)
        {
            var cartId = await sender.Send(new CreateCartCommand(cart));
            return CreatedAtAction(nameof(GetCart), new { CartId = cartId.Value }, cartId);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCart(CartId cartId)
        {
            await sender.Send(new DeleteCartCommand(cartId));
            return NoContent();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("active")]
        public async Task<IActionResult> ActiveCart(RequestActiveCart request)
        {
            await sender.Send(new ActiveCartCommand(request.cartId,request.lineItemId));
            return NoContent();
        }

    }
    public record RequestActiveCart(Guid cartId, Guid lineItemId);
}
