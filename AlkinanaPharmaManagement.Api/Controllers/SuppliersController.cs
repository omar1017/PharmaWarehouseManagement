using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Application.Suppliers.Active;
using AlkinanaPharmaManagment.Application.Suppliers.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagement.Api.Controllers;

[Authorize(Roles = "Administrator")]
[Route("api/[controller]")]
[ApiController]
public class SuppliersController : ControllerBase
{
    private readonly ISender sender;
    public SuppliersController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]SupplierSearchRequest request) => 
        Ok(await sender.Send(new GetSuppliersQuery(request)));

    [HttpPut("{supplierId}")]
    public async Task<IActionResult> ActiveSupplier(Guid supplierId){
        await sender.Send(new ActiveSupplierCommand(supplierId));
        return NoContent();
    }
}
