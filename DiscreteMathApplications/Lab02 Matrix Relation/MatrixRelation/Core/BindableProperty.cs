using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRelation.Core
{
    public class BindableProperty<T> : INotifyPropertyChanged
    {
        private T? _value;
        public T? Value
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

        public event PropertyChangedEventHandler? PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BindableProperty()
        {
            _value = default(T);
        }

        public BindableProperty(T? value)
        {
            Value = value;
        }

        public static implicit operator T?(BindableProperty<T> property) => property.Value;
        public static explicit operator BindableProperty<T>(T value) => new BindableProperty<T>(value);
    }
}
}
