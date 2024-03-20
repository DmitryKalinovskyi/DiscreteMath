using System.Collections.Generic;

namespace Lab01_Discrete_Math.Services
{
    internal interface IDiscreteCalculator
    {
        public List<T> Unique<T>(List<T> a);

        public List<T> Union<T>(List<T> a, List<T> b);

        public List<T> Intersection<T>(List<T> a, List<T> b);

        public List<T> Difference<T>(List<T> a, List<T> b);

        public List<T> SymmetricDifference<T>(List<T> a, List<T> b);
    }
}
