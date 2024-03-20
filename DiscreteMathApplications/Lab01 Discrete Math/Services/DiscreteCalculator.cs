using System.Collections.Generic;

namespace Lab01_Discrete_Math.Services
{
    public class DiscreteCalculator : IDiscreteCalculator
    {
        public List<T> Unique<T>(List<T> a)
        {
            List<T> result = new List<T>();

            foreach (T t in a)
            {
                if (result.Contains(t) == false)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        public List<T> Intersection<T>(List<T> a, List<T> b)
        {
            List<T> result = new();

            foreach (T item in a)
            {
                if (b.Contains(item))
                {
                    result.Add(item);
                }
            }

            return Unique(result);
        }

        public List<T> Difference<T>(List<T> a, List<T> b)
        {
            List<T> result = new();

            foreach (T item in a)
            {
                if (b.Contains(item) == false)
                {
                    result.Add(item);
                }
            }

            return Unique(result);
        }

        public List<T> SymmetricDifference<T>(List<T> a, List<T> b)
        {
            List<T> result = new();

            foreach (T item in a)
            {
                if (b.Contains(item) == false)
                    result.Add(item);
            }

            foreach (T item in b)
            {
                if (a.Contains(item) == false)
                    result.Add(item);
            }

            return Unique(result);
        }

        public List<T> Union<T>(List<T> a, List<T> b)
        {
            List<T> result = new(a);

            foreach (T item in b)
            {
                if (result.Contains(item) == false)
                {
                    result.Add(item);
                }
            }

            return Unique(result);
        }
    }
}
