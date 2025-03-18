using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts
{
    public class LineItemResponse
    {
        public LineItemId LineItemId { get; set; }
        public ProductResponse Product { get; set; }
        public int Quantity { get; set; }
        public bool IsFulfilled { get; set; }
    }
}
