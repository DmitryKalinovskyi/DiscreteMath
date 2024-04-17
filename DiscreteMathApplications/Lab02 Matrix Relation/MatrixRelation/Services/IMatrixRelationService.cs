using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MatrixRelation.Services
{
    public interface IMatrixRelationService<T>
    {
        public bool IsHaveRelation(T a, T b);
        public bool[,] GetRelationMatrix(IList<T> a, IList<T> b);
    }
}
