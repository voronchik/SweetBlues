using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SweetBlues
{
	public static class OrderEspreso
	{
		//структура меню Меню -> Напої -> Кава -> 
		public static IReplyMarkup GetOrderEspreso()
		{
			InlineKeyboardButton[][] buttons = new InlineKeyboardButton[][]
			{
				new InlineKeyboardButton[]{
					new InlineKeyboardButton("Замовити Еспресо")
					{
						CallbackData = "eba4f9c9-0273-4035-9217-c743491a04c8" //guid - тестовий
					},
					new InlineKeyboardButton("Повернутися до кавових напоїв")
					{
						CallbackData = "backCoffeeDrinks"
					}
				}
			};
			InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);
			return keyboard;
		}
	}
}
