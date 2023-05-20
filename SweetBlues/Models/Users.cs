using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetBlues.Models
{
	internal class Users
	{
		public Guid Id { get; set; }	
		public long TelegramId { get; set; }
		public string Name { get; set; }
		public Basket Basket { get; set; }	

	}
}
