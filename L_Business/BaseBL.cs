using F_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business
{
    public class BaseBL<T> where T : class, new()
    {
        protected readonly AgroCampoContext _dbContext;

        public BaseBL(AgroCampoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            var resultado = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            return resultado;
        }

        public virtual async Task<T> Add(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
