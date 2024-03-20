using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_Discrete_Math.Services
{
    public interface ISetOperationService
    {
        public HashSet<object> Unique(IEnumerable<object> a);
        public HashSet<object> Union(IEnumerable<object> a, IEnumerable<object> b);
        public HashSet<object> Difference(IEnumerable<object> a, IEnumerable<object> b);
        public HashSet<object> SymmetricDifference(IEnumerable<object> a, IEnumerable<object> b);
        public HashSet<object> Intersection(IEnumerable<object> a, IEnumerable<object> b);
    }
}
