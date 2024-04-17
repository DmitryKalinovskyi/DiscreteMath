using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRelation.Services
{
    public class MatrixRelationService<T> : IMatrixRelationService<T>
    {
        private Func<T, T, bool>? _relationCondition;

        public MatrixRelationService()
        {
            _relationCondition = null;
        }

        public MatrixRelationService(Func<T, T, bool> relationCondition)
        {
            _relationCondition = relationCondition;
        }

        public void SetRelationCondition(Func<T, T, bool> relationCondition)
        {
            _relationCondition = relationCondition;
        }

        public bool[,] GetRelationMatrix(IList<T> a, IList<T> b)
        {
            bool[,] result = new bool[a.Count(), b.Count()];

            for (int i = 0; i < a.Count(); i++)
            {
                for (int j = 0; j < b.Count(); j++)
                {
                    result[i, j] = IsHaveRelation(a[i], b[j]);
                }
            }

            return result;
        }

        public bool IsHaveRelation(T a, T b)
        {
            // by default all elements don't have relation
            return _relationCondition?.Invoke(a, b) ?? false;
        }
    }
}
