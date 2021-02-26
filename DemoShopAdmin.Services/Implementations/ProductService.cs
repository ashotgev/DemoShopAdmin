
using DemoShopAdmin.Models;
using DemoShopAdmin.Services.Data;
using DemoShopAdmin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Services.Implementations
{
    internal class ProductService : BaseService<Product> , IProductService
    {
        public ProductService(DemoShopAdminDbContext context) : base(context) { }

        public override async Task<Product> GetAsync(int? id)
        {
            return await _context.Product.Include(x => x.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Product.Include(x => x.Category).ToListAsync();
        }
    }
}
