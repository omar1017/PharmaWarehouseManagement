using AlkinanaPharmaManagment.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Abstractions.Identity
{
    public interface IUserService
    {
        Task<List<AccountRepo>> GetAccountRepos();
        Task<AccountRepo> GetAccountRepo(string RepoId);
        Task<bool> DeleteAccount(string RepoId);
        Task<bool> UpdateAccount(AccountRepo accountRepo);
        Task<bool> CreateRole(RoleRequest roleRequest);
        Task<List<RoleResponse>> GetRolesResponse();
        Task<bool> DeleteRole(string Id);
        Task<string> AssignRole(RoleAssign roleAssign);
        Task<List<AccountRepo>> GetAccountByRole(string role);
        string UserId {  get; }
    }
}
