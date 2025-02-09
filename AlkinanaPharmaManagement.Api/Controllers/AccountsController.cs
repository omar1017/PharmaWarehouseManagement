using AlkinanaPharma.Identity.Models;
using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlkinanaPharmaManagement.Api.Controllers;

//[Authorize(Roles ="Administrator")]
[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAuthenticationService authenticationService;
    private readonly IUserService userService;
    private readonly UserManager<ApplicationUser> userManager;

    public AccountsController(
        IAuthenticationService authenticationService,
        IUserService userService,
        UserManager<ApplicationUser> userManager)
    {
        this.authenticationService = authenticationService;
        this.userService = userService;
        this.userManager = userManager;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticationRequest request) =>
        Ok(await authenticationService.LogIn(request));

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request) =>
        Ok(await authenticationService.Register(request));


    [HttpGet]
    public async Task<IActionResult> GetUsers() =>
        Ok(await userService.GetAccountRepos());


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUser(string Id) =>
        Ok(await userService.GetAccountRepo(Id));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteRole(string Id) {
       await userService.DeleteAccount(Id);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAccount(AccountRepo accountRepo)
    {
        await userService.UpdateAccount(accountRepo);

        return NoContent();
    }

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
}


