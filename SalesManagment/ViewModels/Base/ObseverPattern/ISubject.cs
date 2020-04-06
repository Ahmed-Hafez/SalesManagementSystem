using System.Collections.Generic;

namespace SalesManagment
{
    public interface ISubject<T>
    {
        /// <summary>
        /// Register a new observer
        /// </summary>
        /// <param name="observer">The observer to add</param>
        void RegisterObserver(IObserver<T> observer);

        /// <summary>
        /// Removes an observer
        /// </summary>
        /// <param name="observer">The observer to remove</param>
        void RemoveObserver(IObserver<T> observer);

        /// <summary>
        /// Notifing all observer that something changed
        /// </summary>
        void NotifyObservers();
    }
}
