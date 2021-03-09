using System;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
	/// <summary>
	/// Holds data for an Employee
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	public class Employee
	{

		/// <summary>
		/// Gets or sets the employee identifier.
		/// </summary>
		/// <value>
		/// The employee identifier.
		/// </value>
		public int EmployeeID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[Required(ErrorMessage = "Please enter a name.")]
		public string Name { get; set; }

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
		/// Gets or sets the phone.
		/// </summary>
		/// <value>
		/// The phone.
		/// </value>
		[Required(ErrorMessage = "Please enter a phone number.")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone number format is not valid.")]
		public string Phone { get; set; }
	}
}
