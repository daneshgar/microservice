using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.IRepository.Command.Base;
using IDP.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IDP.Infra.Repository.Command
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly ShopDbContext _Context;

        public CommandRepository(ShopDbContext Context)
        {
            _Context = Context;
        }
        public async Task<bool> Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
            await _Context.SaveChangesAsync();
            return true;
        }

        public async  Task<T> Insert(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _Context.Entry(entity).State=EntityState.Modified;
                await _Context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex) { 
                throw ex;
            }
        }
    }
}
