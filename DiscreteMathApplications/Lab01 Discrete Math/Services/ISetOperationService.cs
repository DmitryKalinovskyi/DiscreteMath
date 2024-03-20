using System.Collections.Generic;

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
