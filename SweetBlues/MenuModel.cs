using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SweetBlues
{
	public static class MenuModel
	{
		//структура меню Головне меню
		public static IReplyMarkup GetMainMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("Меню"), new KeyboardButton("Стрічка новин")},
				new KeyboardButton[]{new KeyboardButton("Зарахувати бонуси"), new KeyboardButton("Мій профіль")},
				new KeyboardButton[]{new KeyboardButton("Задонатити на ЗСУ!!!")}
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Меню
		public static IReplyMarkup GetMenuMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("Напої"), new KeyboardButton("Тортики")},
				new KeyboardButton[]{new KeyboardButton("Фірмове печіво"), new KeyboardButton("Морозиво")},
				new KeyboardButton[]{new KeyboardButton("<-- Назад до головного меню") }
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Стрічка новин
		public static IReplyMarkup GetNewsFeed()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("<-- Назад до головного меню") }
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Зарахувати бонуси
		public static IReplyMarkup GetCreditBonusesMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Мій профіль
		public static IReplyMarkup GetMyProfileMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("Оновити дані"), new KeyboardButton("Мої бонуси")},
				new KeyboardButton[]{new KeyboardButton("<-- Назад до головного меню"), new KeyboardButton("Зробіть нас кращіми!")}
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Задонатити на ЗСУ
		public static IReplyMarkup GetDonateArmyMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("<-- Назад до головного меню")}
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Мій профіль -> Оновити дані
		public static IReplyMarkup GetUpdateDataMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("Ім'я та прізвище")},
				new KeyboardButton[]{new KeyboardButton("Номер телефону"), new KeyboardButton("Email")},
				new KeyboardButton[]{new KeyboardButton("<-- Назад до мого профілю")}
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Мій профіль -> Мої бонуси
		public static IReplyMarkup GetMyBonusMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("Історія нарахування"), new KeyboardButton("Використати бонуси")},
				new KeyboardButton[]{new KeyboardButton("<-- Назад до мого профілю")}
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		//структура меню Мій профіль -> Зробіть нас кращіми
		public static IReplyMarkup GetMakeUsBetterMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("<-- Назад до мого профілю")}
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}
	}
}
