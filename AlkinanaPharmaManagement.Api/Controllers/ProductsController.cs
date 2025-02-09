using AlkinanaPharmaManagment.Application.Products.Create;
using AlkinanaPharmaManagment.Application.Products.Delete;
using AlkinanaPharmaManagment.Application.Products.Get;
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

[Authorize(Roles = "Administrator")]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender sender;

    public ProductsController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts() => Ok(await sender.Send(new GetProductsQuery()));

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProductById(Guid Id) => Ok(await sender.Send(new GetProductByIdQuery(Id)));

    [HttpGet("company/{company}")]
    public async Task<IActionResult> GetProductsByCompany(string company) => Ok(await sender.Send(new GetProductsByCompanyQuery(company)));

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetProductsByName(string name) => Ok(await sender.Send(new GetProductsByNameQuery(name)));

    [HttpGet("supplier/{supplier}")]
    public async Task<IActionResult> GetProductsBySupplier(string supplier) => Ok(await sender.Send(new GetProductsBySupplierQuery(supplier)));

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] ProductRequest request) => CreatedAtAction(nameof(CreateProduct), new { Id = await sender.Send(new CreateProductCommand(request)) });

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromForm]ProductUpdate product)
    {
        await sender.Send(new UpdateProductCommand(product));
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteProduct(Guid Id)
    {
        await sender.Send(new DeleteProductCommand(Id));
        return NoContent();
    }
}

