using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SquaredCircle_bot.Messages
{
    /// <summary>
    /// An interface which provides send message logic
    /// </summary>
    interface IMessageSender
    {
        /// <summary>
        /// Sends text message with reply to the author 
        /// </summary>
        /// <param name="textMessage">Message body</param>
        /// <param name="telegramBotClient">Bot client <see cref="ITelegramBotClient"/></param>
        /// <param name="message">Message <see cref="Message"/></param>
        /// <param name="cancellationToken">Cancellation token<see cref="CancellationToken"/></param>
        void SendTextMessageWithReplyAsync(string textMessage, ITelegramBotClient telegramBotClient, Message message,
            CancellationToken cancellationToken);

        /// <summary>
        /// Sends sticker
        /// </summary>
        /// <param name="stickerLink">Sticker link</param>
        /// <param name="telegramBotClient">Bot client <see cref="ITelegramBotClient"/></param>
        /// <param name="message">Message <see cref="Message"/></param>
        /// <param name="cancellationToken">Cancellation token<see cref="CancellationToken"/></param>
        void SendStickerAsync(string stickerLink, ITelegramBotClient telegramBotClient, Message message,
            CancellationToken cancellationToken);
    }
}