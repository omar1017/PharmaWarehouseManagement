using AlkinanaPharma.Identity.DBContext;
using AlkinanaPharma.Identity.Models;
using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Models.Identity;
using AlkinanaPharmaManagment.Application.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers.Events;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly AlkinanaPharmaIdentityDbContext context;

        public AuthenticationService(
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSetting> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ISupplierRepository supplierRepository,
            AlkinanaPharmaIdentityDbContext context
            )
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.supplierRepository = supplierRepository;
            this.context = context;
        }
        public async Task<AuthenticationResponse> LogIn(AuthenticationRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new Exception("user not found");
            }

            if (user.EmailConfirmed == false) {
                throw new Exception("not confirmed");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                throw new Exception("credentials aren't valid.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var refreshToken = await GenerateAndStoreRefreshToken(user, jwtSecurityToken.Id);

            var response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                RefreshToken = refreshToken.Token,
                Email = request.Email,
                UserName = user.UserName

            };
            return response;
        }

        private async Task<RefreshToken> GenerateAndStoreRefreshToken(ApplicationUser user, string jwtId)
        {
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Token = GenerateRefreshToken(),
                JwtId = jwtId,
                ExpiryDate = DateTime.UtcNow.AddMonths(23),
                AddedDate = DateTime.UtcNow
            };

            await context.RefreshTokens.AddAsync(refreshToken);
            await context.SaveChangesAsync(); // أضف هذا السطر
            return refreshToken;
        }

        public async Task<AuthenticationResponse> RefreshTokenAsync(string token, string refreshToken)
        {
            RefreshToken? rrefreshToken = await context.RefreshTokens.Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Token == refreshToken);

            if (rrefreshToken is null || rrefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                throw new ApplicationException("The refresh token has expired");
            }
            
            JwtSecurityToken jwtSecurityToken = await GenerateToken(rrefreshToken.User);
            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            rrefreshToken.Token = GenerateRefreshToken();
            rrefreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(23);

            await context.SaveChangesAsync();

            return new AuthenticationResponse
            {
                Token = accessToken,
                RefreshToken = rrefreshToken.Token,
            };
        }

       
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = false,
                UserName = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };

            var result = await userManager.CreateAsync(user, request.Password);





            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "CustomerAccount");

                var supplier = Supplier.CreateSupplier(
                    Guid.Parse(user.Id),
                    request.PharmaName,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    request.Address);

                supplier.Raise(new SupplierCreatedEvent(supplier));

                await supplierRepository.AddSupplier(supplier);

                await supplierRepository.SaveChangeAsync();

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
        new Claim(JwtRegisteredClaimNames.Iss, jwtSettings.Value.Issuer), // استخدم jwtSettings.Value هنا
        new Claim(JwtRegisteredClaimNames.Aud, jwtSettings.Value.Audience),
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
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.Value.DurationInMinutes),
                signingCredentials: signingCredentials
            );

            

            return jwtSecurityToken;
        }

        private string GenerateRefreshToken()
        {
            
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }

    }
}
