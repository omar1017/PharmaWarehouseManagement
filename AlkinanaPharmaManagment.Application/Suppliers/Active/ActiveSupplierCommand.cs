using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Suppliers.Active
{
    public record ActiveSupplierCommand(Guid supplierId) : ICommand<Unit>;

}
