using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> Entities;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Entities = _context.Set<T>();
        }

        public async Task<T> Add(T item)
        {
            Entities.Add(item);
            await this.Save();
            return item;
        }

        public async Task<T> Update(T item)
        {
            Entities.Update(item);
            await this.Save();
            return item;
        }

        public async Task Delete(T item)
        {
            Entities.Remove(item);
            await this.Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}