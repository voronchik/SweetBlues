using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SweetBlues
{
	public static class MenuDrinks
	{
		//структура меню Меню -> Напої
		public static IReplyMarkup GetMenuDrinks()
		{
			InlineKeyboardButton[][] buttons = new InlineKeyboardButton[][]
			{
				new InlineKeyboardButton[]{
					new InlineKeyboardButton("Кава")
					{
						CallbackData = "coffee"
					},
					new InlineKeyboardButton("Чай")
					{
						CallbackData = "tea"
					},
				},
				new InlineKeyboardButton[]{
					new InlineKeyboardButton("Лимонад")
					{
						CallbackData = "lemonad"
					},
					new InlineKeyboardButton("Коктель")
					{
						CallbackData = "coctail"
					},
				},
				new InlineKeyboardButton[]{
					new InlineKeyboardButton("Напої від Шефа")
					{
						CallbackData = "chiefDrinks"
					}
				}
			};
			InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);
			return keyboard;
		}
	}
}
