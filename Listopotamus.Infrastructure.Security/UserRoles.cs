namespace Listopotamus.Infrastructure.Security
{
    /// <summary>
    /// Represents the user roles.
    /// </summary>
    public class UserRoles
    {
        /// <summary>
        /// The user role.
        /// </summary>
        public const string User = "User";

        /// <summary>
        /// The admin role.
        /// </summary>
        public const string Admin = "Admin";

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <returns>The list of user roles.</returns>
        public static List<string> GetAll()
        {
            return new List<string>() { Admin, User };
        }
    }
}
