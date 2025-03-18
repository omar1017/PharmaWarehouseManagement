using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.Get
{
    public sealed class CartResponse
    {
        public CartId CartId { get; set; }
        public bool isFulfilled { get; set; }
        public CustomerResponse Customer { get; set; }
        public List<LineItemResponse> products { get; set; } = new();
        public DateTime? DateCreated { get; set; }
    }
}
