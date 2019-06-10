using System;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// A basic command that runs an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action mAction;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the <see cref="RelayCommand"/> class
        /// </summary>
        /// <param name="action">The action to run</param>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Command Methods

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the commands Action
        /// </summary>
        /// <param name="parameter">Required parameters</param>
        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
