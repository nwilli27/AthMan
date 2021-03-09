using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthMan.Models
{
	/// <summary>
	/// Holds data for a Item
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	public class Item
	{

		/// <summary>
		/// Gets or sets the item identifier.
		/// </summary>
		/// <value>
		/// The item identifier.
		/// </value>
		public int ItemID { get; set; }

		/// <summary>
		/// Gets or sets the item code.
		/// </summary>
		/// <value>
		/// The item code.
		/// </value>
		[Required(ErrorMessage = "Please enter a code.")]
		public string ItemCode { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[Required(ErrorMessage = "Please enter a name.")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the yearly price.
		/// </summary>
		/// <value>
		/// The yearly price.
		/// </value>
		[Required(ErrorMessage = "Please enter a yearly price.")]
		[Range(0, double.MaxValue, ErrorMessage = "Please enter a yearly price greater than 0.")]
		public decimal? YearlyPrice { get; set; }

		/// <summary>
		/// Gets or sets the release date.
		/// </summary>
		/// <value>
		/// The release date.
		/// </value>
		public DateTime ReleaseDate { get; set; } = DateTime.Now;
	}
}
