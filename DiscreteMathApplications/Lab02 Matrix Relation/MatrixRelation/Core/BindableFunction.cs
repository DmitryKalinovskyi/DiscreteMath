using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRelation.Core
{
    public class BindableFunction<T> : BindableProperty<T>
    {
        public BindableFunction(Func<T> func, params BindableProperty<dynamic>[] dependendProperties): base(dependendProperties)
        {
            _func = func;
        }

        private Func<T> _func;

        public override T? Value { get => _func(); set => throw new InvalidOperationException("You can't set value to the function"); }
    }
}
