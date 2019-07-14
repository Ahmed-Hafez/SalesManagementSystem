namespace SalesManagment
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// The factory method to create instances
        /// </summary>
        object GetInstances(object obj);
    }
}
