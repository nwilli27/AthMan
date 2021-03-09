using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Models
{
	/// <summary>
	/// Holds data for a Client View
	/// 
	/// Author: Nolan Williams
	/// Date: 3/9/2021
	/// </summary>
	public class ClientViewModel
	{

		/// <summary>
		/// Gets or sets the countries.
		/// </summary>
		/// <value>
		/// The countries.
		/// </value>
		public IList<Country> Countries { get; set; }

		/// <summary>
		/// Gets or sets the client.
		/// </summary>
		/// <value>
		/// The client.
		/// </value>
		public Client Client { get; set; }
	}
}
