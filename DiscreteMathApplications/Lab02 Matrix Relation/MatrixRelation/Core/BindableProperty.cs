using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRelation.Core
{
    public abstract class BindableProperty<T> : INotifyPropertyChanged
    {
        public abstract T? Value { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BindableProperty(params BindableProperty<dynamic>[] dependendProperties)
        {
            foreach(var bindableProp in dependendProperties)
            {
                bindableProp.PropertyChanged += (sender, args) => OnPropertyChanged("Value");
            }
        }

        public BindableProperty(T? value)
        {
            Value = value;
        }

        public static implicit operator T?(BindableProperty<T> property) => property.Value;
    }
}
