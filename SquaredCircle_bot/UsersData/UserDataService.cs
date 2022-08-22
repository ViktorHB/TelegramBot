using System.Collections.Generic;
using System.Linq;

namespace SquaredCircle_bot.UsersData
{
    /// <inheritdoc cref="IUserDataService"/>
    internal class UserDataService : IUserDataService
    {
        private readonly IUserDataRepository _userDataRepository;
        private readonly IList<UserData> _users;

        /// <summary>
        /// Creates instance of <see cref="UserDataService"/>
        /// </summary>
        /// <param name="userDataRepository">Data repository <see cref="IUserDataRepository"/></param>
        public UserDataService(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
            _users = _userDataRepository.GetUsersDataList() as IList<UserData>;
        }

        /// <inheritdoc cref="IUserDataService"/>
        public UserData GetUserDataById(long id) => _users.FirstOrDefault(x => x.Id == id);

        /// <inheritdoc cref="IUserDataService"/>
        public UserData GetUserDataByUsername(string username) => _users.FirstOrDefault(x => x.Username == username);

        /// <inheritdoc cref="IUserDataService"/>
        public IEnumerable<UserData> GetUsersDataList() => _users;

        /// <inheritdoc cref="IUserDataService"/>
        public void SaveUserData(UserData userData)
        {
            if (IsUserExist(userData))
            {
                return;
            }

            _userDataRepository.SaveUserData(userData);
            _users.Add(userData);
        }

        private bool IsUserExist(UserData userData) => _users.Any(x => x.Id == userData.Id
                                  && x.ChatId == userData.ChatId/*
                                  && x.LastName.Equals(userData.LastName)
                                  && x.FirsName.Equals(userData.FirsName)
                                  && x.Username.Equals(userData.Username)*/);
    }
}