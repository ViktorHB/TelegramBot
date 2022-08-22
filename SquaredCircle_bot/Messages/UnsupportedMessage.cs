using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SquaredCircle_bot.Messages
{
    /// <inheritdoc cref="IMessage"/>
    /// <summary>
    /// Unsupported message logic
    /// </summary>
    class UnsupportedMessage : IMessage
    {
        /// <inheritdoc cref="IMessage"/>
        public void Execute(ITelegramBotClient telegramBotClient, Message message, CancellationToken cancellationToken)
        {
            // Do nothing
            // Temporary stub before cover all type
        }
    }
}