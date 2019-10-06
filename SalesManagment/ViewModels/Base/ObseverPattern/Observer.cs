namespace SalesManagment
{
    public interface Observer
    {
        /// <summary>
        /// Updating the observers when any thing changed
        /// </summary>
        void Update<T>(params object[] parameters)
            where T : BaseRowViewerViewModel;
    }
}
