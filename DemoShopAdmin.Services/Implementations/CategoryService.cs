using DemoShopAdmin.Models;
using DemoShopAdmin.Services.Data;
using DemoShopAdmin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Services.Implementations
{
    internal class CategoryService : BaseService<Category> , ICategoryService
    {
        public CategoryService(DemoShopAdminDbContext context) : base(context){ }
    }
}
