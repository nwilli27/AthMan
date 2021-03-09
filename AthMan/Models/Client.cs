using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AthMan.Models
{
	/// <summary>
	/// Handles data for a Client
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	public class Client
	{

		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>
		/// The client identifier.
		/// </value>
		public int ClientID { get; set; }

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		[Required(ErrorMessage = "Please enter a first name.")]
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		[Required(ErrorMessage = "Please enter a last name.")]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>
		/// The address.
		/// </value>
		[Required(ErrorMessage = "Please enter a Address.")]
		public string Address { get; set; }

		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>
		/// The city.
		/// </value>
		[Required(ErrorMessage = "Please enter a City.")]
		public string City { get; set; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		[Required(ErrorMessage = "Please enter a State.")]
		public string State { get; set; }

		/// <summary>
		/// Gets or sets the postal code.
		/// </summary>
		/// <value>
		/// The postal code.
		/// </value>
		[Required(ErrorMessage = "Please enter a postal code.")]
		[RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Entered zip format is not valid.")]
		public string PostalCode { get; set; }

		/// <summary>
		/// Gets or sets the country identifier.
		/// </summary>
		/// <value>
		/// The country identifier.
		/// </value>
		[Required(ErrorMessage = "Please select a country.")]
		public string CountryID { get; set; }

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>
		/// The country.
		/// </value>
		public Country Country { get; set; }

		/// <summary>
		/// Gets or sets the phone.
		/// </summary>
		/// <value>
		/// The phone.
		/// </value>
		[Required(ErrorMessage = "Please enter a phone number.")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone number format is not valid.")]
		public string Phone { get; set; }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>
		/// The email.
		/// </value>
		[Required(ErrorMessage = "Please enter a email.")]
		[EmailAddress(ErrorMessage = "Entered email format is not valid.")]
		public string Email { get; set; }

		/// <summary>
		/// Gets the full name.
		/// </summary>
		/// <value>
		/// The full name.
		/// </value>
		public string FullName => FirstName + " " + LastName;   // read-only property
	}
}