using System.Collections.Generic;

namespace SalesManagment
{
    public interface Subject
    {
        /// <summary>
        /// Register a new observer
        /// </summary>
        /// <param name="observer">The observer to add</param>
        void RegisterObserver(Observer observer);

        /// <summary>
        /// Removes an observer
        /// </summary>
        /// <param name="observer">The observer to remove</param>
        void RemoveObserver(Observer observer);

        /// <summary>
        /// Notifing all observer that something changed
        /// </summary>
        void NotifyObservers();
    }
}
