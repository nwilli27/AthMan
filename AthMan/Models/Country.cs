using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
	/// <summary>
	/// Holds data for a Country
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	public class Country
    {

		/// <summary>
		/// Gets or sets the country identifier.
		/// </summary>
		/// <value>
		/// The country identifier.
		/// </value>
		public string CountryID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }
    }
}
