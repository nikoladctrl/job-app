using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.Helpers
{
    public class PaginationResult<T, F> where T: class where F: class
    {
        public List<T> Items { get; set; }
        public PaginationParams Pagination { get; set; }
        public F FilteringParams { get; set; }
        
        public PaginationResult()
        {
        }

        public PaginationResult(List<T> items, int page, int size, int total)
        {
            Items = items;
            Pagination = new PaginationParams(page, size, total);
        }

        public PaginationResult(List<T> items, int page, int size, int total, F filteringParams)
        {
            Items = items;
            Pagination = new PaginationParams(page, size, total);
            FilteringParams = filteringParams;
        }
    }
}