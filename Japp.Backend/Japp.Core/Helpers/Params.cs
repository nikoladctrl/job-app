using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.Helpers
{
    public class Params<T> where T : class
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public T FilteringParams { get; set; }
    }
}