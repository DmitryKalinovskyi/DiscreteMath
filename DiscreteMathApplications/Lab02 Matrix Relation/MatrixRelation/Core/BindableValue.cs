using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRelation.Core
{
    public class BindableValue<T> : BindableProperty<T>
    {
        private T? _value;
        public override T? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public BindableValue(T value) : base()
        {
            Value = value;
        }


        public BindableValue(params BindableProperty<dynamic>[] dependendProperties)
        {
            foreach (var bindableProp in dependendProperties)
            {
                bindableProp.PropertyChanged += (sender, args) => OnPropertyChanged("Value");
            }
        }
    }
}
