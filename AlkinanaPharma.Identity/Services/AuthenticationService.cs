using AlkinanaPharma.Identity.Models;
using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Models.Identity;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlkinanaPharma.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOptions<JwtSetting> jwtSettings;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly ISupplierRepository supplierRepository;

        public AuthenticationService(
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSetting> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ISupplierRepository supplierRepository
            )
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.supplierRepository = supplierRepository;
        }
        public async Task<AuthenticationResponse> LogIn(AuthenticationRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new Exception("user not found");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                throw new Exception("credentials aren't valid.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = request.Email,
                UserName = user.UserName

            };
            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true,
                UserName = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };

            var result = await userManager.CreateAsync(user, request.Password);





            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "CustomerAccount");

                var supplier = Supplier.CreateSupplier(Guid.Parse(user.Id),request.PharmaName,user.FirstName,user.LastName,user.Email,request.Address);
                await supplierRepository.AddSupplier(supplier);
                return new RegistrationResponse
                {
                    UserId = user.Id
                };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("*{0}\n", err.Description);
                }

                throw new Exception(str.ToString());
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            // تعديل اسم الحقل الخاص بالأدوار ليصبح "role"
            var roleClaims = roles.Select(q => new Claim("role", q)).ToList();

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Iss,
            configuration.GetSection("JwtSettings").GetSection("Issuer").Value),
        new Claim(JwtRegisteredClaimNames.Aud,
            configuration.GetSection("JwtSettings").GetSection("Audience").Value),
        new Claim("uid", user.Id)
    }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Value.Issuer,
                audience: jwtSettings.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(jwtSettings.Value.DurationInMinutes),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }

    }
}
