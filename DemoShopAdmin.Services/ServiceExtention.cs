using DemoShopAdmin.Services.Implementations;
using DemoShopAdmin.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShopAdmin.Service.Extentions
{
    public static class ServiceExtention
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
