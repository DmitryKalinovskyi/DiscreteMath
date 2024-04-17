using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.Services
{
    public interface IArrayConvertor<T>
    {
        public T[] ConvertFromString(string str);
    }
}
