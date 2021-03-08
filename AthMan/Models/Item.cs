using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthMan.Models
{
	public class Item
	{
		public int ItemID { get; set; }

		public string ItemCode { get; set; }

		public string Name { get; set; }

		public decimal YearlyPrice { get; set; }

		public DateTime ReleaseDate { get; set; } = DateTime.Now;
	}
}
