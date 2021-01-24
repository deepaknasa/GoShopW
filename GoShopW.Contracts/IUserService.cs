using GoShopW.Models;

namespace GoShopW.Contracts
{
    /// <summary>
    /// Contract define method to access <see cref="User"/>.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get user detail which also contain user token.
        /// </summary>
        /// <remarks>
        /// For now it's only returning hard-coded user data for test purposes.
        /// </remarks>
        /// <returns><see cref="User"/> object with all relevant attributes.</returns>
        User GetUser();
    }
}
