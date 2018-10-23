using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHierarchiesDemo
{
    public class BindableBase : INotifyPropertyChanged
    {
        // public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected virtual void SetProperty<T> (ref T member, T val,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val))
                return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
