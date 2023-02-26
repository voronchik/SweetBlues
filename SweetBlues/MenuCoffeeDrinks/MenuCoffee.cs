using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SweetBlues
{
	public static class MenuCoffee
	{
		//структура меню Меню -> Напої -> Кава -> 
		public static IReplyMarkup GetMenuCoffee()
		{
			InlineKeyboardButton[][] buttons = new InlineKeyboardButton[][]
			{
				new InlineKeyboardButton[]{
					new InlineKeyboardButton("Еспресо")
					{
						CallbackData = "espreso"
					},
					new InlineKeyboardButton("Амерікано")
					{
						CallbackData = "americano"
					},
				},
				new InlineKeyboardButton[]{
					new InlineKeyboardButton("Капучіно")
					{
						CallbackData = "capuchino"
					},
					new InlineKeyboardButton("Лате")
					{
						CallbackData = "late"
					},
				},
				new InlineKeyboardButton[]{
					new InlineKeyboardButton("Повернутися до меню Напої")
					{
						CallbackData = "backToMenudrinks"
					}
				}
			};
			InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);
			return keyboard;
		}
	}
}
