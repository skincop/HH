using System;

using System.Windows.Input;


namespace HH.Infastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
#pragma warning disable CS8612 // Допустимость значения NULL для ссылочных типов в типе не совпадает с явно реализованным членом.
        public event EventHandler CanExecuteChanged
#pragma warning restore CS8612 // Допустимость значения NULL для ссылочных типов в типе не совпадает с явно реализованным членом.
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

#pragma warning disable CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public abstract bool CanExecute(object parameter);
#pragma warning restore CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).

#pragma warning disable CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public abstract void Execute(object parameter);
#pragma warning restore CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
    }
}
