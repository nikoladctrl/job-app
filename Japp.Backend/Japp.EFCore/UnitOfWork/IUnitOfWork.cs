using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.UnitOfWork
{
    public interface IUnitOfWork<T> where T : class
    {
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task Delete(T item);
        Task Save();
    }
}