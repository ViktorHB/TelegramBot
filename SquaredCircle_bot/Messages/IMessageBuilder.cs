using Telegram.Bot.Types.Enums;

namespace SquaredCircle_bot.Messages
{
    /// <summary>
    /// An interface which provide logic to build massage instance 
    /// </summary>
    public interface IMessageBuilder
    {
        /// <summary>
        /// Builds message instance
        /// </summary>
        /// <param name="messageType">Message type <see cref="MessageType"/></param>
        /// <returns>Message instance <see cref="IMessage"/></returns>
        IMessage Build(MessageType messageType);
    }
}