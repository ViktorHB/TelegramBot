using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace SquaredCircle_bot.Messages
{
    /// <inheritdoc cref="IMessageSender"/>
    /// <summary>
    /// Class which implement send message logic
    /// </summary>
    internal class MessageSender : IMessageSender
    {
        /// <inheritdoc cref="IMessageSender"/>
        public async void SendTextMessageWithReplyAsync(string textMessage, ITelegramBotClient telegramBotClient, Message message, CancellationToken cancellationToken)
        {
            await telegramBotClient.SendTextMessageAsync(message.Chat.Id, textMessage,
                 ParseMode.Html,
                 cancellationToken: cancellationToken, replyToMessageId: message.MessageId);
        }

        /// <inheritdoc cref="IMessageSender"/>
        public async void SendStickerAsync(string stickerLink, ITelegramBotClient telegramBotClient, Message message,
            CancellationToken cancellationToken)
        {

            await telegramBotClient.SendStickerAsync(message.Chat.Id, new InputOnlineFile(stickerLink), replyToMessageId: message.MessageId);
        }
    }
}
