using AlkinanaPharma.Identity.Models;
using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace AlkinanaPharma.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IHttpContextAccessor httpContextAccessor;

    public string UserId {  get; private set; }

    public UserService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IHttpContextAccessor httpContextAccessor
        )
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.httpContextAccessor = httpContextAccessor;
        SetId();
    }
    

    public async Task<string> AssignRole(RoleAssign roleAssign)
    {
        var user = await userManager.FindByIdAsync(roleAssign.UserId);
        if (user is null)
        {
            throw new Exception("user not found");
        }

        var role = await roleManager.FindByIdAsync(roleAssign.RoleId);

        if (role is null)
        {
            throw new Exception("role not found");
        }

        var result = await userManager.AddToRoleAsync(user, role.Name!);

        if (!result.Succeeded)
        {
            throw new Exception("role assign not completed");
        }

        var error = result.Errors.FirstOrDefault();

        return error!.Description;
    }

    public async Task<bool> CreateRole(RoleRequest roleRequest)
    {
        if (string.IsNullOrEmpty(roleRequest.RoleName))
        {
            throw new Exception("role is null");
        }

        var roleExist = await roleManager.RoleExistsAsync(roleRequest.RoleName);

        if (roleExist) {
            throw new Exception("role is exist");
        }

        var roleResult = await roleManager.CreateAsync(new IdentityRole(roleRequest.RoleName));

        if(! roleResult.Succeeded)
            throw new Exception("role not created");
        return roleResult.Succeeded;
    }

    public async Task<bool> DeleteAccount(string RepoId)
    {
        var user = await userManager.FindByIdAsync(RepoId);

        if (user is null)
        {
            throw new Exception("user not found");
        }

        var result = await userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            throw new Exception("user not deleted");
        }
        return result.Succeeded;
    }

    public async Task<bool> DeleteRole(string Id)
    {
        var role = await roleManager.FindByIdAsync(Id);

        if (role is null)
            throw new Exception("role not found");

        var result = await roleManager.DeleteAsync(role);

        if (!result.Succeeded)
            throw new Exception("role not deleted");

        return result.Succeeded;
    }

    public async Task<AccountRepo> GetAccountRepo(string RepoId)
    {
        var repo = await userManager.FindByIdAsync(RepoId);

        return new AccountRepo
        {
            Email = repo.Email,
            FirstName = repo.FirstName,
            LastName = repo.LastName,
        };
    }

    public async Task<List<AccountRepo>> GetAccountRepos()
    {
        var repos = await userManager.GetUsersInRoleAsync("CustomerAccount");

        return repos.Select(q => new AccountRepo
        {
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName,
        }).ToList();
    }

    public async Task<List<AccountRepo>> GetAccountByRole(string role)
    {
        var repos = await userManager.GetUsersInRoleAsync(role);

        return repos.Select(q => new AccountRepo
        {
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName,
        }).ToList();
    }

    public async Task<List<RoleResponse>> GetRolesResponse()
    {
        var roles = await roleManager.Roles.Select(r=>new RoleResponse{
            Id = r.Id,
            Name = r.Name,
            TotalUsers = userManager.GetUsersInRoleAsync(r.Name!).Result.Count
        }).ToListAsync();

        return roles;
    }

      

    public async Task<bool> UpdateAccount(AccountRepo accountRepo)
    {
        var user = await userManager.FindByEmailAsync(accountRepo.Email);

        if (user is null)
        {
            throw new Exception("user not found");
        }

        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new Exception("user not updated");
        }
        return result.Succeeded;
    }

    private void SetId()
    {
        var context = httpContextAccessor.HttpContext;

        if (context?.User?.Identity?.IsAuthenticated == true)
        {
            // جلب الـ ID باستخدام الـ Claim الصحيح
            UserId = context.User.FindFirstValue("uid");
        }


    }

   
}
