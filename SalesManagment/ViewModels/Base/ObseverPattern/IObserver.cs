namespace SalesManagment
{
    public interface IObserver
    {
        /// <summary>
        /// Updating the observers when any thing changed
        /// </summary>
        void Update<T>(params object[] parameters)
            where T : BaseRowViewerViewModel;
    }
}
