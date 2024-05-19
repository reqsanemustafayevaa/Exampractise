using Exam.Core.Models;
using Exam.Core.repositories.Interfaces;
using Exam.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Repositories.implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
           _appDbContext = appDbContext;
        }
        public DbSet<Tentity> Table => _appDbContext.Set<Tentity>();

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Tentity entity)
        {
           Table.Add(entity);
        }

        public void Delete(Tentity entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<Tentity> GetAllAsync(Expression<Func<Tentity, bool>>? expression = null, params string[]? includes)
        {
            var query=Table.AsQueryable();
            return expression is not null 
                ? query.Where(expression) 
                : query;
        }

        public Task<Tentity> GetSingleAsync(Expression<Func<Tentity, bool>>? expression = null, params string[]? includes)
        {
            var query = Table.AsQueryable();
            return expression is not null
                ? query.Where(expression).FirstOrDefaultAsync()
                : query.FirstOrDefaultAsync();
        }
    }
}
