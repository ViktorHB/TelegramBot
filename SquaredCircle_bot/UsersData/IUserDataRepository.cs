using System.Collections.Generic;

namespace SquaredCircle_bot.UsersData
{
    /// <summary>
    /// An interface which provide logic to do get/store user data
    /// </summary>
    internal interface IUserDataRepository
    {
        /// <summary>
        /// Get users list
        /// </summary>
        /// <returns>List of <see cref="UserData"/></returns>
        IEnumerable<UserData> GetUsersDataList();

        /// <summary>
        /// Save data <see cref="UserData"/> to the repository
        /// </summary>
        /// <param name="userData">User data <see cref="UserData"/></param>
        void SaveUserData(UserData userData);
    }
}