using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Abstractions.HubServices
{
    public interface IRaiseMethod<T>
    {
        Task RaiseClients(string Group, string method, T entity);
    }
}
