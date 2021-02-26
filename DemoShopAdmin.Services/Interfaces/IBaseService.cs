using DemoShopAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoShopAdmin.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetAsync(int? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
