using DomainLayer.Common;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entites;

        public Repository(AppDbContext context)
        {
            _entites = _context.Set<T>();
        }

        public async Task CreateAsnyc(T entity)
        {
            if(entity == null) {throw new ArgumentNullException(nameof(entity)); }
            await _entites.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsnyc(T entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }
            _entites.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entites.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if(id ==null) { throw new ArgumentNullException(); }

            T entity = await _entites.FindAsync(id);

            if(entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }
            return entity;
        }

        public Task UpdateAsnyc(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
