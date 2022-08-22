using SquaredCircle_bot.Messages;
using SquaredCircle_bot.UsersData;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace SquaredCircle_bot
{
    /// <summary>
    /// Class which implements main logic for the bot
    /// </summary>
    public class Bot
    {
        private readonly IMessageBuilder _messageBuilder;
        private readonly IUserDataService _userDataService;

        /// <summary>
        /// Telegram Bot Client <see cref="ITelegramBotClient"/>
        /// </summary>
        public TelegramBotClient TelegramBotClient { get; private set; }

        /// <summary>
        /// Chat id
        /// </summary>
        public long? ChatId;

        /// <summary>
        /// Last message id
        /// </summary>
        public int LastMessageId;

        /// <summary>
        /// Creates instance of <see cref="Bot"/>
        /// </summary>
        /// <param name="userDataService">User data service object <see cref="IUserDataService"/></param>
        /// <param name="messageBuilder">Message builder object <see cref="IMessageBuilder"/></param>
        public Bot(IUserDataService userDataService, IMessageBuilder messageBuilder)
        {
            _userDataService = userDataService;
            _messageBuilder = messageBuilder;
            const string token = "token";
            TelegramBotClient = new TelegramBotClient(token);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            TelegramBotClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            TelegramBotClient.OnMakingApiRequest += _telegramBotClient_OnMakingApiRequest;
            TelegramBotClient.OnApiResponseReceived += _telegramBotClient_OnApiResponseReceived; ;
        }

        private ValueTask _telegramBotClient_OnApiResponseReceived(ITelegramBotClient botClient,
            ApiResponseEventArgs args, CancellationToken cancellationToken = default)
        {
            return new ValueTask();
        }

        private ValueTask _telegramBotClient_OnMakingApiRequest(ITelegramBotClient botClient,
            ApiRequestEventArgs args, CancellationToken cancellationToken = default)
        {
            return new ValueTask();
        }

        private void HandleErrorAsync(ITelegramBotClient telegramBotClient, Exception exception, CancellationToken cancellationToken)
        {
            // ignored
        }

        private void HandleUpdateAsync(ITelegramBotClient telegramBotClient, Update msg, CancellationToken cancellationToken)
        {
            var message = msg.Message;

            if (message == null)
            {
                return;
            }

            _userDataService.SaveUserData(new UserData
            {
                ChatId = message.Chat.Id,
                Id = message?.From?.Id,
                LastName = message?.From?.LastName,
                FirsName = message?.From?.FirstName,
                Username = message?.From?.Username,
            });

            //Skip if old
            if (IsOldMessage(message.Date))
            {
                return;
            }

            //to clear conversation from the UI
            if (ChatId == null)
            {
                ChatId = message.Chat.Id;
            }

            _messageBuilder.Build(message.Type).Execute(telegramBotClient, message, cancellationToken);
            LastMessageId = message.MessageId;
        }

        private bool IsOldMessage(DateTime messageDate)
        {
            DateTime universalDateNow =
                TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.Now);
            DateTime universalMessageDate =
                TimeZone.CurrentTimeZone.ToUniversalTime(messageDate);
            return universalMessageDate.Day == universalDateNow.Day
                   && universalMessageDate.Hour == universalDateNow.Hour
                   && universalMessageDate.Minute == universalDateNow.Minute
                   && universalMessageDate.Month == universalDateNow.Month
                   && universalMessageDate.Year == universalDateNow.Year
                   && Math.Abs(universalMessageDate.Second - universalDateNow.Second) > 3;
        }
    }
}