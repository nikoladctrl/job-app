using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DataContext _context;
        
        protected BaseRepository(DataContext context)
        {
            _context = context;
        }
    }
}