using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SquaredCircle_bot.Messages
{
    /// <inheritdoc cref="IMessage"/>
    /// <summary>
    /// Photo message logic
    /// </summary>
    internal class PhotoMessage : IMessage
    {
        private readonly IMessageSender _textMessageSender;

        /// <summary>
        /// Creates instance of <see cref="TextMessage"/>
        /// </summary>
        /// <param name="textMessageSender">Message sender object<see cref="IMessageSender"/></param>
        public PhotoMessage(IMessageSender textMessageSender)
        {
            _textMessageSender = textMessageSender;
        }

        /// <inheritdoc cref="IMessage"/>
        public void Execute(ITelegramBotClient telegramBotClient, Message message, CancellationToken cancellationToken)
        {
            _textMessageSender.SendStickerAsync("https://tlgrm.ru/_/stickers/dc7/a36/dc7a3659-1457-4506-9294-0d28f529bb0a/1.webp"
                ,telegramBotClient, message, cancellationToken);
        }
    }
}