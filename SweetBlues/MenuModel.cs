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
		public static IReplyMarkup GetMainMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("Далі -->")},
				new KeyboardButton[]{new KeyboardButton("Зарахувати бонуси"), new KeyboardButton("Мій профіль")},
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}

		public static IReplyMarkup GetMyProfileMenu()
		{
			KeyboardButton[][] buttons = new KeyboardButton[][]
			{
				new KeyboardButton[]{new KeyboardButton("Оновити дані"), new KeyboardButton("Мої бонуси")},
				new KeyboardButton[]{new KeyboardButton("<-- Повернутися до головного меню")},
			};
			ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons);
			return keyboard;
		}
	}
}
