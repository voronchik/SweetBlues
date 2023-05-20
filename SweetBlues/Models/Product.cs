using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetBlues.Models
{
	internal class Product
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public double Price { get; set; }
		public int Count { get; set; }
	}
}
