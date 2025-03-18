using AlkinanaPharma.Identity.Models;
using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Models.Identity;
using AlkinanaPharmaManagment.Application.Suppliers.Active;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AlkinanaPharmaManagement.Api.Controllers;

//[Authorize(Roles ="Administrator")]
[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAuthenticationService authenticationService;
    private readonly IUserService userService;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly ISender sender;

    public AccountsController(
        IAuthenticationService authenticationService,
        IUserService userService,
        UserManager<ApplicationUser> userManager,
        ISender sender)
    {
        this.authenticationService = authenticationService;
        this.userService = userService;
        this.userManager = userManager;
        this.sender = sender;
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("active/{id}")]
    public async Task<IActionResult> ActiveAccount(Guid id)
    {
        await sender.Send(new ActiveSupplierCommand(id));
        return NoContent();
    }
        

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticationRequest request) =>
        Ok(await authenticationService.LogIn(request));

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request) =>
        Ok(await authenticationService.Register(request));

    [Authorize(Roles = "Administrator")]
    [HttpGet]
    public async Task<IActionResult> GetUsers() =>
        Ok(await userService.GetAccountRepos());

    [Authorize(Roles = "Administrator")]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUser(string Id) =>
        Ok(await userService.GetAccountRepo(Id));

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteRole(string Id) {
       await userService.DeleteAccount(Id);
        return NoContent();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateAccount(AccountRepo accountRepo)
    {
        await userService.UpdateAccount(accountRepo);

        return NoContent();
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("UserProfile")]
    public async Task<IActionResult> GetUserProfile()
    {
        var userID = User.Claims.FirstOrDefault(x => x.Type == "uid")?.Value;

        if (userID == null)
        {
            return Unauthorized(new { Message = "User ID not found in claims." });
        }

        var userDetails = await userManager.FindByIdAsync(userID);

        if (userDetails == null)
        {
            return NotFound(new { Message = "User not found." });
        }

        return Ok(new
        {
            Email = userDetails.Email,
            FullName = userDetails.FirstName + " " + userDetails.LastName,
        });

    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        try
        {
            var response = await authenticationService.RefreshTokenAsync(request.Token, request.RefreshToken);
            return Ok(response);
        }
        catch (SecurityTokenException ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }
    }

    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}



