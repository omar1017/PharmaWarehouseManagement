using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Application.Products.Active;
using AlkinanaPharmaManagment.Application.Products.Create;
using AlkinanaPharmaManagment.Application.Products.Delete;
using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Application.Products.GetAllProduct;
using AlkinanaPharmaManagment.Application.Products.GetByCompany;
using AlkinanaPharmaManagment.Application.Products.GetById;
using AlkinanaPharmaManagment.Application.Products.GetByName;
using AlkinanaPharmaManagment.Application.Products.GetBySupplier;
using AlkinanaPharmaManagment.Application.Products.Update;
using AlkinanaPharmaManagment.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagement.Api.Controllers;

//[Authorize(Roles = "Administrator")]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender sender;

    public ProductsController(ISender sender)
    {
        this.sender = sender;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] ProductSearchRequest request) =>
        Ok(await sender.Send(new GetProductsQuery(request, User)));

    [AllowAnonymous]
    [HttpGet("all")]
    public async Task<IActionResult> GetActiveProducts([FromQuery] ProductSearchRequest request) =>
        Ok(await sender.Send(new GetAllProductQuery(request)));

    [Authorize(Roles = "Administrator")]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProductById(Guid Id) => 
        Ok(await sender.Send(new GetProductByIdQuery(Id)));

    [Authorize(Roles = "Administrator, CustomerAccount")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm]ProductRequest request) => 
        CreatedAtAction(nameof(CreateProduct), new { Id = await sender.Send(new CreateProductCommand(request,User)) });

    [Authorize(Roles = "Administrator, CustomerAccount")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id,[FromForm]ProductUpdate product)
    {
        await sender.Send(new UpdateProductCommand(id,product,User));
        return NoContent();
    }

    [Authorize(Roles = "Administrator, CustomerAccount")]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteProduct(Guid Id)
    {
        await sender.Send(new DeleteProductCommand(Id));
        return NoContent();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("Active/{Id}")]
    public async Task<IActionResult> ActiveProduct(Guid Id)
    {
        await sender.Send(new ActiveProductCommand(Id));
        return NoContent();
    }
}

