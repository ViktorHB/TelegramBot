using System;
using System.Collections.Generic;
using System.Threading;
using SquaredCircle_bot.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SquaredCircle_bot.Messages
{
    /// <inheritdoc cref="IMessage"/>
    /// <summary>
    /// Text message logic
    /// </summary>
    internal class TextMessage : IMessage
    {
        private readonly IMessageSender _textMessageSender;

        /// <summary>
        /// Creates instance of <see cref="TextMessage"/>
        /// </summary>
        /// <param name="textMessageSender">Message sender object<see cref="IMessageSender"/></param>
        public TextMessage(IMessageSender textMessageSender)
        {
            _textMessageSender = textMessageSender;
        }

        private readonly List<string> _zorinaNicknameList = new List<string>
        {
            "Зоріночка",
            "Квіточка",
            "Кішечка",
            "Мавпочка",
            "Тілочка",
        };

        private readonly Random _random = new Random();

        /// <inheritdoc cref="IMessage"/>
        public void Execute(ITelegramBotClient telegramBotClient, Message message, CancellationToken cancellationToken)
        {
            if (message.Text.ToLower().Contains("xxx"))
            {
                _textMessageSender.SendTextMessageWithReplyAsync($"<b>@{message.From.Username}</b>,<b><i> не сварися</i></b>", telegramBotClient, message,
                    cancellationToken);
                return;
            }

            switch (message.From.Id)
            {
                case UserId.Zorina:
                    _textMessageSender.SendTextMessageWithReplyAsync($"<b>{ZorinaNicknameGenerator()} ♥</b>", telegramBotClient, message,
                        cancellationToken);
                    break;
                case UserId.Master:
                    _textMessageSender.SendTextMessageWithReplyAsync($"<b>Вітаю, мій володарю</b>", telegramBotClient, message,
                        cancellationToken);
                    break;
                case UserId.Kolya:
                    _textMessageSender.SendTextMessageWithReplyAsync($"<b>Да, капітан</b>", telegramBotClient, message,
                        cancellationToken);
                    break;
                case UserId.Artem:
                    _textMessageSender.SendTextMessageWithReplyAsync($"<b>u da man</b>", telegramBotClient, message,
                        cancellationToken);
                    break;
                default:
                    _textMessageSender.SendTextMessageWithReplyAsync($"<b>Шo нада, холоп?</b>", telegramBotClient, message,
                        cancellationToken);
                    break;
            }
        }

        private string ZorinaNicknameGenerator()
        {
            return _zorinaNicknameList[_random.Next(0, _zorinaNicknameList.Count)];
        }
    }
}