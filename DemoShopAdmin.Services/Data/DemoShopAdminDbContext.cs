using Microsoft.EntityFrameworkCore;

namespace DemoShopAdmin.Services.Data
{
    public class DemoShopAdminDbContext : DbContext
    {
        public DemoShopAdminDbContext (DbContextOptions<DemoShopAdminDbContext> options)
            : base(options)
        {
        }

        public DbSet<DemoShopAdmin.Models.Category> Category { get; set; }
        public DbSet<DemoShopAdmin.Models.Product> Product { get; set; }
    }
}
