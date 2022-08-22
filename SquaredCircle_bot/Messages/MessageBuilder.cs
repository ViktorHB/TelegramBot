using System;
using Telegram.Bot.Types.Enums;

namespace SquaredCircle_bot.Messages
{
    /// <inheritdoc cref="IMessageBuilder"/>
    /// <summary>
    /// Class which creates message instance
    /// </summary>
    internal class MessageBuilder : IMessageBuilder
    {
        private readonly IMessageSender _textMessageSender;

        /// <summary>
        /// Create instance of <see cref="MessageBuilder"/>
        /// </summary>
        /// <param name="textMessageSender">Message sender object <see cref="IMessageSender"/></param>
        public MessageBuilder(IMessageSender textMessageSender)
        {
            _textMessageSender = textMessageSender;
        }

        /// <inheritdoc cref="IMessageBuilder"/>
        public IMessage Build(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Unknown:
                    break;
                case MessageType.Text:
                    return new TextMessage(_textMessageSender);
                case MessageType.Photo:
                    return new PhotoMessage(_textMessageSender);
                case MessageType.Audio:
                    break;
                case MessageType.Video:
                    break;
                case MessageType.Voice:
                    break;
                case MessageType.Document:
                    break;
                case MessageType.Sticker:
                    break;
                case MessageType.Location:
                    break;
                case MessageType.Contact:
                    break;
                case MessageType.Venue:
                    break;
                case MessageType.Game:
                    break;
                case MessageType.VideoNote:
                    break;
                case MessageType.Invoice:
                    break;
                case MessageType.SuccessfulPayment:
                    break;
                case MessageType.WebsiteConnected:
                    break;
                case MessageType.ChatMembersAdded:
                    break;
                case MessageType.ChatMemberLeft:
                    break;
                case MessageType.ChatTitleChanged:
                    break;
                case MessageType.ChatPhotoChanged:
                    break;
                case MessageType.MessagePinned:
                    break;
                case MessageType.ChatPhotoDeleted:
                    break;
                case MessageType.GroupCreated:
                    break;
                case MessageType.SupergroupCreated:
                    break;
                case MessageType.ChannelCreated:
                    break;
                case MessageType.MigratedToSupergroup:
                    break;
                case MessageType.MigratedFromGroup:
                    break;
                case MessageType.Poll:
                    break;
                case MessageType.Dice:
                    break;
                case MessageType.MessageAutoDeleteTimerChanged:
                    break;
                case MessageType.ProximityAlertTriggered:
                    break;
                case MessageType.WebAppData:
                    break;
                case MessageType.VideoChatScheduled:
                    break;
                case MessageType.VideoChatStarted:
                    break;
                case MessageType.VideoChatEnded:
                    break;
                case MessageType.VideoChatParticipantsInvited:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return new UnsupportedMessage();
        }
    }
}