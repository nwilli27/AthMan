using System;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
	/// <summary>
	/// Holds data for an Incident
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	[IncidentDateRange(ErrorMessage = "Please select a closed date greater than the open date.")]
	public class Incident
	{

		/// <summary>
		/// Gets or sets the incident identifier.
		/// </summary>
		/// <value>
		/// The incident identifier.
		/// </value>
		public int IncidentID { get; set; }

		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>
		/// The client identifier.
		/// </value>
		[Range(1, Int32.MaxValue, ErrorMessage = "Please select a client.")]
		public int ClientID { get; set; }

		/// <summary>
		/// Gets or sets the client.
		/// </summary>
		/// <value>
		/// The client.
		/// </value>
		public Client Client { get; set; }

		/// <summary>
		/// Gets or sets the item identifier.
		/// </summary>
		/// <value>
		/// The item identifier.
		/// </value>
		[Range(1, Int32.MaxValue, ErrorMessage = "Please select a item.")]
		public int ItemID { get; set; }

		/// <summary>
		/// Gets or sets the item.
		/// </summary>
		/// <value>
		/// The item.
		/// </value>
		public Item Item { get; set; }

		/// <summary>
		/// Gets or sets the employee identifier.
		/// </summary>
		/// <value>
		/// The employee identifier.
		/// </value>
		[Range(1, Int32.MaxValue, ErrorMessage = "Please select a employee.")]
		public int? EmployeeID { get; set; }

		/// <summary>
		/// Gets or sets the employee.
		/// </summary>
		/// <value>
		/// The employee.
		/// </value>
		public Employee Employee { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		[Required(ErrorMessage = "Please enter a title.")]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[Required(ErrorMessage = "Please enter a title.")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the date opened.
		/// </summary>
		/// <value>
		/// The date opened.
		/// </value>
		public DateTime DateOpened { get; set; } = DateTime.Today;

		/// <summary>
		/// Gets or sets the date closed.
		/// </summary>
		/// <value>
		/// The date closed.
		/// </value>
		public DateTime? DateClosed { get; set; } = null;
	}
}