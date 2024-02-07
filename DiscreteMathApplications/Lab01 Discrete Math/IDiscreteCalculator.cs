using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_Discrete_Math
{
    internal interface IDiscreteCalculator
    {
        public List<T> Union<T>(List<T> a, List<T> b);
        
        public List<T> Intersection<T>(List<T> a, List<T> b);
        
        public List<T> Difference<T>(List<T> a, List<T> b);
        
        public List<T> SymmetricDifference<T>(List<T> a, List<T> b);
    }
}
