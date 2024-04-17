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

        public bool[,] GetRelationMatrix(IList<T> A, IList<T> B)
        {
            bool[,] result = new bool[A.Count(), B.Count()];

            for (int i = 0; i < A.Count(); i++)
            {
                for (int j = 0; j < B.Count(); j++)
                {
                    result[i, j] = IsHaveRelation(A[i], B[j]);
                }
            }

            return result;
        }

        public bool IsHaveRelation(T a, T b)
        {
            // by default all elements don't have relation
            return _relationCondition?.Invoke(a, b) ?? false;
        }

        public bool[,] GetRelationMatrix(IEnumerable<T> A, IEnumerable<T> B)
        {
            bool[,] result = new bool[A.Count(), B.Count()];

            int i = 0;
            foreach(T a in A)
            {
                int j = 0;
                foreach(T b in B)
                {
                    result[i, j] = IsHaveRelation(a, b);
                    j++;
                }

                i++;
            }

            return result;
        }
    }
}
