﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Noodle.Wpf.Keystone
{
    public class RelayCommandAsync<T> : ICommand
    {
        #region Fields

        private readonly Func<T, Task> _execute;
        private readonly Predicate<T> _canExecute;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of RelayCommand/>.
        /// </summary>
        /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommandAsync(Func<T, Task> execute) : this(execute, null)
        {
        }

        /// <inheritdoc cref="RelayCommand{T}"/>
        /// <param name="canExecute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommandAsync(Func<T, Task> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state.
        ///</summary>
        ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        ///<returns>
        ///true if this command can be executed; otherwise, false.
        ///</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public async void Execute(object parameter)
        {
            await _execute((T)parameter);
        }

        #endregion
    }
}
