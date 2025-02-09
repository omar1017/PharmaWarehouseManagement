using AlkinanaPharmaManagment.Application.Models.Identity;
using Azure.Identity;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Abstractions.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> LogIn(AuthenticationRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
