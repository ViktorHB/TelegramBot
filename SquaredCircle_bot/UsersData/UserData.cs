using System;

namespace SquaredCircle_bot.UsersData
{
    /// <summary>
    /// User data entity
    /// </summary>
    [Serializable]
    public class UserData
    {
        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Chat id
        /// </summary>
        public long? ChatId { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirsName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
    }
}