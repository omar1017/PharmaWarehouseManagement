using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products
{
    public class ProductListResponse
    {
        public List<ProductResponse> Products { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
