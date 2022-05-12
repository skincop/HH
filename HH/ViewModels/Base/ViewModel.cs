using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace HH.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string ProperyName = null)
        {
            field = value;
            OnPropertyChanged();
            return true;

        }
    }
}
