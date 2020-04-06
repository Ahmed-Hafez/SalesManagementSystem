namespace SalesManagment
{
    public interface IObserver<TDad>
    {
        /// <summary>
        /// Updating the observers when any thing changed
        /// </summary>
        void Update<T>(params object[] parameters)
            where T : TDad;
    }
}
