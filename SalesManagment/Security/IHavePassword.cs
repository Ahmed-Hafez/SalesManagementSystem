using System.Security;

namespace SalesManagment
{
    /// <summary>
    /// An interface for any class provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// The secured password
        /// </summary>
        SecureString SecurePassword { get; }
    }
}
