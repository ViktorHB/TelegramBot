using System.Collections.Generic;

namespace SquaredCircle_bot.UsersData
{
    /// <summary>
    /// An interface which provide logic to do manipulations with user data
    /// </summary>
    public interface IUserDataService
    {
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>User data <see cref="UserData"/></returns>
        UserData GetUserDataById(long id);

        /// <summary>
        /// Get user by nickname
        /// </summary>
        /// <param name="nickname">user nickname</param>
        /// <returns>User data <see cref="UserData"/></returns>
        UserData GetUserDataByUsername(string nickname);

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