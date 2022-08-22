using System;
using System.Threading;
using System.Windows.Input;
using Telegram.Bot;

namespace SquaredCircle_bot
{
    /// <summary>
    /// View model for <see cref="MainWindowViewModel"/>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Bot _bot;

        /// <summary>
        /// Command which executes on clean button click
        /// </summary>
        public ICommand ClearMouseDownCommand { get; set; }

        /// <summary>
        /// Command which executes on clean quit click
        /// </summary>
        public ICommand QuitMouseDownCommand { get; set; }

        /// <summary>
        /// Creates instance for <see cref="MainWindowViewModel"/>
        /// </summary>
        /// <param name="bot">Bot instance <see cref="Bot"/></param>
        public MainWindowViewModel(Bot bot)
        {
            _bot = bot;
            ClearMouseDownCommand = new RelayCommand(ClearMouseDownCommandExecute);
            QuitMouseDownCommand = new RelayCommand(QuitMouseDownCommandExecute);
        }

        private void QuitMouseDownCommandExecute(object obj)
        {
            Environment.Exit(1);
        }

        private void ClearMouseDownCommandExecute(object obj)
        {
            if (_bot.ChatId == null)
            {
                return;
            }

            for (int i = _bot.LastMessageId; i > 0; i--)
            {
                try
                {
                    _bot.TelegramBotClient.DeleteMessageAsync(_bot.ChatId, i, CancellationToken.None);
                }
                catch (Exception)
                {
                    Console.WriteLine($@"Message did not exist. MessageId = {i}");
                }
            }
            Console.WriteLine(@"Clearing chat finished");
        }
    }
}