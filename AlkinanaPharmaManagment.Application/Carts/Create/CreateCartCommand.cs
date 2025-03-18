using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlkinanaPharmaManagment.Application.Carts
{
    public record CreateCartCommand(CartRequest cartRequest) : ICommand<CartId>;
    public record CartRequest(string pharmaName, string name, string phone, string address, List<Item> items);
    public record Item(Guid productId,int quantity);

}



