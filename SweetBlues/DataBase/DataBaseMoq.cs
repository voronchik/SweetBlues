using SweetBlues.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

using User = SweetBlues.Models.Users;



namespace SweetBlues.DataBase
{
	internal static class DataBaseMoq
	{
		public static List<User> Users { get; set; } = new List<User>();
		public static List<Product> Product { get; set; } = new List<Product>()
		{
			new Product()
			{
				Id = Guid.Parse("eba4f9c9-0273-4035-9217-c743491a04c8"),
				Title = "Еспресо",
				Price = 30
			}
		};
		public static void AppendUser(Message message)
		{
			long telegramId = message.Chat.Id;
			var user = Users.FirstOrDefault(u => u.TelegramId == telegramId);

			if (user == null)
			{
				Users.Add(new User()
				{
					Id = Guid.NewGuid(),
					TelegramId = telegramId,
					Name = message.Chat.FirstName,
					Basket = new Basket()
					{
						Id = Guid.NewGuid(),
						Products = new List<Product>()
					}
				});
			}
		}

		public static async Task SendMessageAllUsers(this TelegramBotClient bot, string message)
		{
			foreach (var user in Users)
			{
				await bot.SendTextMessageAsync(user.TelegramId, message);
			}
		}

		public static async Task AppendProductToBasket(this TelegramBotClient bot, CallbackQuery query)
		{
			long telegramId = query.From.Id;
			var user = Users.FirstOrDefault(u => u.TelegramId == telegramId);
			if (user != null)
			{
				if (Guid.TryParse(query.Data, out Guid id))
				{
					var product = Product.FirstOrDefault(u => u.Id == id);
					if (product != null)
					{
						var basket = user.Basket.Products;
						var productInBasket = basket.FirstOrDefault(p => p.Title == product.Title);
						if (productInBasket != null)
						{
							productInBasket.Count++;
							await bot.SendTextMessageAsync(query.From.Id, $"{product.Title} в кошику у кількості {productInBasket.Count}");
						}
						else
						{
							basket.Add(new Product()
							{
								Id = Guid.NewGuid(),
								Count = 1,
								Title = product.Title,
								Price = product.Price
							});
							await bot.SendTextMessageAsync(query.From.Id, $"{product.Title} додано до кошика.");
						}
					}
					else
					{
						await bot.SendTextMessageAsync(query.From.Id, "Продукта не існує");
					}
				}
				else
				{
					await bot.SendTextMessageAsync(query.From.Id, "Не вдалося перетворити ID");
				}
			}
			else
			{
				await bot.SendTextMessageAsync(query.From.Id, "Користувача не існує.");
			}
		}



		public static async Task ShowBasket(this TelegramBotClient bot, Message message)
		{
			long telegramId = message.Chat.Id;
			var user = Users.FirstOrDefault(u => u.TelegramId == telegramId);
			if (user != null)
			{
				//user.Basket
				foreach (var product in user.Basket.Products)
				{
					string result = $"{product.Title} / {product.Count} / {product.Count * product.Price}";
				}
			}
			else
			{
				await bot.SendTextMessageAsync(telegramId, "Користувача не існує.");
			}
		}




	}
}
