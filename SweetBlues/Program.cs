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
			CancellationTokenSource source = new CancellationTokenSource();
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
			
			//вхід в головне меню
			if (mess == "/start")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Радий Вас вітати у нашій кав'ярні!",
					replyMarkup: MenuModel.GetMainMenu());
			}

			//Перехід до меню Меню
			else if (mess == "меню")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Сподіваємось Ви знайдете для себе щось смачненьке.",
					replyMarkup: MenuModel.GetMenuMenu());
			}

			//Перехід до меню Лента новин
			else if (mess == "стрічка новин")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "А тут ви побачите інформацію про нас і нашу діяльність.",
					replyMarkup: MenuModel.GetNewsFeed());
			}

			//перехід до меню Мій профіль
			else if (mess == "мій профіль")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вітаю, це Ваш профіль",
					replyMarkup: MenuModel.GetMyProfileMenu());
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вказавши в профілі ім'я, прізвище, номер телефону та email," +
					" ми будемо знати як до Вас звертатися та як Вам надіслати інформацію про смачні пропозиції.");
			}

			//перехід до меню Задонатити на ЗСУ

			else if (mess == "задонатити на зсу!!!")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вискакує котик з Банкою для донату.",
					replyMarkup: MenuModel.GetDonateArmyMenu());
			}

			//перехід Мій профіль -> Оновити дані
			else if (mess == "оновити дані")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Зараз Ви можете оновити свої особисті дані.",
					replyMarkup: MenuModel.GetUpdateDataMenu());
			}



			//перехід Мій профіль -> Мої бонуси
			else if (mess == "мої бонуси")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "На вашому балансі * бонусів.",
					replyMarkup: MenuModel.GetMyBonusMenu());
			}

			//перехід Мій профіль -> Зробіть нас кращіми!
			else if (mess == "зробіть нас кращіми!")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Ми будемо дуже вдячні вам, якщо Ви підкажете що нам" +
					" змінити щоб бути ще краще.",
					replyMarkup: MenuModel.GetMakeUsBetterMenu());
			}

			//повернення з Мій профіль до Головного меню
			else if (mess == "<-- назад до головного меню")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вітаю, Ви у головному меню.",
					replyMarkup: MenuModel.GetMainMenu());
			}

			//повернення з Оновити дані\Мої бонуси\Зробіть нас кращіми до Мій профіль
			else if (mess == "<-- назад до мого профілю")
			{
				await SweetBlues.SendTextMessageAsync(message.Chat.Id, "Вітаю, Ви у меню Мій профіль.",
					replyMarkup: MenuModel.GetMyProfileMenu());
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
				if (message.Type == MessageType.Text)
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
