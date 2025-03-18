using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Application.Carts;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Application.Customers;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AlkinanaPharmaManagment.Application.Products.Get;

namespace AlkinanaPharmaManagment.Infrastructure.Repositoryies;

internal class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext context;
    private readonly ICustomerRepository customerRepository;
    private readonly IProductRepository productRepository;

    public CartRepository(ApplicationDbContext context,ICustomerRepository customerRepository, IProductRepository productRepository)
    {
        this.context = context;
        this.customerRepository = customerRepository;
        this.productRepository = productRepository;
    }
    public async Task AddAsync(Cart cart)
    {
        await context.Carts.AddAsync(cart);
    }

    public async Task DeleteAsync(Cart cart)
    {
         context.Carts.Remove(cart);
    }

    public async Task<CartListResponse> GetAllAsync(CartSearchRequest request)
    {
        // 1. بناء الاستعلام الأساسي مع العلاقات
        var query = context.Carts
            .AsNoTracking()
            .Include(c => c.Customer)
            .Include(c => c.lineItems) // تغيير lineItems إلى LineItems (حالة الأحرف مهمة)
                .ThenInclude(li => li.Product)
                    .ThenInclude(p => p.Image)
            .AsQueryable();

        // 2. تطبيق الفلترة بشكل صحيح
        if (!string.IsNullOrEmpty(request.Name))
        {
            // افتراض أن customerName هو Value Object
            query = query.Where(c => c.Customer.customerName.Value.Contains(request.Name));
        }

        if (!string.IsNullOrEmpty(request.Pharma))
        {
            // افتراض أن customerName هو Value Object
            query = query.Where(c => c.Customer.pharma.Value.Contains(request.Pharma));
        }

        // 3. الحصول على العدد الإجمالي
        var totalCount = await query.CountAsync();
        // 4. تنفيذ الاستعلام مع التحويل
        var carts = await query
            .OrderByDescending(c => c.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(c => new CartResponse
            {
                CartId = c.CartId,
                DateCreated = c.CreatedAt,
                isFulfilled = c.isFulfilled,
                Customer = new CustomerResponse
                {
                    Id = c.Customer.CustomerId,
                    Name = c.Customer.customerName.Value, // الوصول إلى القيمة عبر .Value
                    PharmaName = c.Customer.pharma,
                    PhoneNumber = c.Customer.Phone,
                    Address = c.Customer.address,
                },
                products = c.lineItems.Select(li => new LineItemResponse // تغيير products إلى Products
                {
                    LineItemId = li.lineItemId,
                    Product = new ProductResponse
                    {
                        ProductId = li.Product.ProductId,
                        ProductName = li.Product.name,
                        Supplier = li.Product.supplier,
                        Price = li.Product.price,
                        PublicPrice =li.Product.PublicPrice,
                        Quantity = li.Product.Quantity,
                        SName = li.Product.SName,
                        ProductImage = li.Product.Image, // افتراض أن Image يحتوي على خاصية Url
                        Description = li.Product.description,
                        CompanyName = li.Product.companyName,
                        IsActive = li.Product.IsActive,
                        Notes = li.Product.Notes,
                    },
                    Quantity = li.quantity,
                    IsFulfilled = li.isFulfilled,
                }).ToList()
            })
            .ToListAsync();

        return new CartListResponse
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
            Carts = carts
        };
    }

    public async Task<Cart> GetByIdAsync(CartId cartId)
    {
        return await context.Carts.Include(c => c.lineItems).FirstOrDefaultAsync(c => c.CartId == cartId);
    }

    public async Task SaveChangeAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cart cart)
    {
         context.Update(cart);
    }
}
