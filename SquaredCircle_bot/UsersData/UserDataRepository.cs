using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SquaredCircle_bot.UsersData
{
    /// <inheritdoc cref="IUserDataRepository"/>
    internal class UserDataRepository : IUserDataRepository
    {
        private readonly string _directoryPath;
        private readonly string _filePath;

        /// <summary>
        /// Creates instance of <see cref="UserDataRepository"/>
        /// </summary>
        public UserDataRepository()
        {
            _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                Assembly.GetExecutingAssembly().GetName().Name);

            _filePath = Path.Combine(_directoryPath, "userData.udb");

            Initialize();
        }

        private void Initialize()
        {

            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                var fs = new FileStream(_filePath, FileMode.Create);
                fs.Dispose();
            }
        }

        /// <inheritdoc cref="IUserDataRepository"/>
        public IEnumerable<UserData> GetUsersDataList()
        {
            return Deserialize().ToList();
        }

        /// <inheritdoc cref="IUserDataRepository"/>
        public void SaveUserData(UserData userData)
        {
            var list = Deserialize();
            list.Add(userData);
            Serialize(list);
        }

        private void Serialize(List<UserData>  userData)
        {
            // Create a hashtable of values that will eventually be serialized.

            // To serialize the hashtable and its key/value pairs,
            // you must first open a stream for writing.
            // In this case, use a file stream.
            var fs = new FileStream(_filePath, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            var formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, userData);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        private List<UserData> Deserialize()
        {
            // Declare the hashtable reference.
            List<UserData> userDataList = new List<UserData>();

            // Open the file containing the data that you want to deserialize.
            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                var formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and
                // assign the reference to the local variable.
                userDataList = (List<UserData>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                return userDataList;
            }
            finally
            {
                fs.Close();
            }

            return userDataList;
        }
    }
}