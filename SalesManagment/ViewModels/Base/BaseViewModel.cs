using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesManagment
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name">The name of the property</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating falg is not set.
        /// 
        /// If the flag is true (indicating that the function is already running then the action is not run.
        /// If the flag is false (indicating that no running function) then the action is run.
        /// 
        /// Once the action is finished if it was run, then the flag is reset to false.
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag indicating that the action is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // Checks if the flag property is true (Meaning that the function is already running)
            if (updatingFlag.GetPropertyValue())
                return;

            // Set the flag property to true to indicate that the function is now running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // Run the passed in action
                await action();
            }
            finally
            {
                // Set the flag property to false, Now the action is finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
