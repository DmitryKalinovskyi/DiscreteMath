using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_Discrete_Math.Services
{
    public class SetOperationService : ISetOperationService
    {
        public HashSet<object> Difference(IEnumerable<object> a, IEnumerable<object> b)
        {
            HashSet<object> bucket = new(b);
            return a.Where(x => bucket.Contains(x) == false).ToHashSet();
        }

        public HashSet<object> Intersection(IEnumerable<object> a, IEnumerable<object> b)
        {
            return a.Intersect(b).ToHashSet();
        }

        public HashSet<object> SymmetricDifference(IEnumerable<object> a, IEnumerable<object> b)
        {
            return Difference(Union(a, b), Intersection(a, b));
        }

        public HashSet<object> Union(IEnumerable<object> a, IEnumerable<object> b)
        {
            return a.Union(b).ToHashSet();
        }

        public HashSet<object> Unique(IEnumerable<object> a)
        {
            return new(a);
        }
    }
}
