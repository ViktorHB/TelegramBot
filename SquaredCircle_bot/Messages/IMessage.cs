using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SquaredCircle_bot.Messages
{
    /// <summary>
    /// An interface which provide logic to messages
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Executes message <see cref="IMessage"/> logic
        /// </summary>
        /// <param name="telegramBotClient">Bot client <see cref="ITelegramBotClient"/></param>
        /// <param name="message">Message <see cref="Message"/></param>
        /// <param name="cancellationToken">Cancellation token<see cref="CancellationToken"/></param>
        void Execute(ITelegramBotClient telegramBotClient, Message message, CancellationToken cancellationToken);
    }
}