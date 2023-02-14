using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SweetBlues
{
	internal class Program
	{
		const string TOKEN = "5823772589:AAEFebA1IvIhtXDGwNPEjDA8_HyoBddkkBM";
		static TelegramBotClient SweetBlues = new TelegramBotClient(TOKEN);

		static void Main(string[] args)
		{
			CancellationTokenSource source= new CancellationTokenSource();
			CancellationToken cancel = source.Token;
			ReceiverOptions options = new ReceiverOptions()
			{
				AllowedUpdates = { }
			};
			SweetBlues.StartReceiving(BotTakeMessage, BotTakeError, options, cancel);

			Console.WriteLine("Bot starting");
			Console.ReadKey();
		}

		static async Task GetMessage(Message message)
		{
			string mess = message.Text.ToLower();
			if (mess == "/start")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Радий Вас вітати у нашій кав'ярні!",
					replyMarkup: MenuModel.GetMainMenu());

			}
			//перехід до меню Мій профіль
			else if (mess == "мій профіль")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вітаю, це Ваш профіль",
					replyMarkup: MenuModel.GetMyProfileMenu());
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вказавши в профілі ім'я, прізввище, номер телефону та email," +
					" ми будемо знати як до Вас звертатися та як Вам надіслати інформацію про смачні пропозиції.");

			}
			//повернення з Мій профіль до Головного меню
			else if (mess == "<-- Повернутися до головного меню")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вітаю, Ви у головному меню.",
					replyMarkup: MenuModel.GetMainMenu());
			}
			else if (mess == "меню")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Коли дізнаюсь про " + mess + " я вам підкажу!");
			}
			else
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Чудово, а що значить " + mess + "?");
			}
		}

		static async Task BotTakeMessage(ITelegramBotClient botClient, Update update, CancellationToken token)
		{
			if (update.Type == UpdateType.Message)
			{
				Message message = update.Message;
				if(message.Type == MessageType.Text)
				{
					await GetMessage(message);
				}
				else if (message.Type == MessageType.Sticker)
				{
					await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Чудовий стікер, мені подобається!");
				}
				else
				{
					await SweetBlues.SendTextMessageAsync(message.Chat.Id, "І що мені з цим робити?");
				}
			}
		}
		
		static async Task BotTakeError(ITelegramBotClient botClient, Exception ex, CancellationToken token)
		{

		}


	}	
}
