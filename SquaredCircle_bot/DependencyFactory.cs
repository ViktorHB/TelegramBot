using SquaredCircle_bot.Messages;
using SquaredCircle_bot.UsersData;

namespace SquaredCircle_bot
{
    /// <summary>
    /// Class which creates depandancies 
    /// </summary>
    internal class DependencyFactory
    {
        /// <summary>
        /// Main window view model <see cref="MainWindowViewModel"/>
        /// </summary>
        public MainWindowViewModel MainWindowViewModel { get; private set; }

        /// <summary>
        /// Creates instance of <see cref="DependencyFactory"/>
        /// </summary>
        public DependencyFactory()
        {
            var textMessageSender = new MessageSender();
            var messageBuilder = new MessageBuilder(textMessageSender);
            var userDataRepository = new UserDataRepository();
            var userDataService = new UserDataService(userDataRepository);
            var bot = new Bot(userDataService, messageBuilder);

            MainWindowViewModel = new MainWindowViewModel(bot);
        }
    }
}