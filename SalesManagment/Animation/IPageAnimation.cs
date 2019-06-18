namespace SalesManagment
{
    public interface IPageAnimation
    {
        /// <summary>
        /// The page load animation
        /// </summary>
        PageAnimation LoadAnimation { get; set; }

        /// <summary>
        /// The page unload animation
        /// </summary>
        PageAnimation UnloadAnimation { get; set; }
    }
}
