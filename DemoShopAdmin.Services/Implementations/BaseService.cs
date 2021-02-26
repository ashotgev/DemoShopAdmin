using DemoShopAdmin.Models;
using DemoShopAdmin.Services.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Services.Implementations
{
    internal class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly DemoShopAdminDbContext _context;
        public readonly DbSet<T> _entities;

        public BaseService(DemoShopAdminDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
        public virtual async Task<T> GetAsync(int? id)
        {
            return await _entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new NullReferenceException();
            else
            await _entities.AddAsync(entity);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new NullReferenceException();
            _entities.Remove(entity);
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new NullReferenceException();
            _entities.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
