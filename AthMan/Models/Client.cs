using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AthMan.Models
{
	public class Client
	{
		public int ClientID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string PostalCode { get; set; }

		public string CountryID { get; set; }
		public Country Country { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public string FullName => FirstName + " " + LastName;   // read-only property
	}
}