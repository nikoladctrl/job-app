using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.Helpers
{
    public class FilteringParams
    {
        public string Filter { get; set; }

        public FilteringParams()
        {
        }

        public FilteringParams(string filter)
        {
            Filter = filter;
        } 
    }
}