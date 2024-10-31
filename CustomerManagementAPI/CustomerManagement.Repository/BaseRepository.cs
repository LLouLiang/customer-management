﻿using CustomerManagement.Interface.Repository;
using CustomerManagement.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly CustomerDbContext _context;
        protected readonly DbSet<T> _dbSet;


        public BaseRepository(CustomerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(long id)
            => await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<long>(e, "Id") == id);

        public async Task<long> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            var idProperty = typeof(T).GetProperty("Id");

            if (idProperty == null)
            {
                throw new InvalidOperationException("Entity does not have an Id property");
            }

            // Return the Id value of the inserted entity
            return (long)idProperty.GetValue(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}

