using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Models
{
	/// <summary>
	/// Handles data for an Incidents view
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	public class IncidentViewModel
	{

		/// <summary>
		/// Gets or sets the incident.
		/// </summary>
		/// <value>
		/// The incident.
		/// </value>
		public Incident Incident { get; set; }

		/// <summary>
		/// Gets or sets the clients.
		/// </summary>
		/// <value>
		/// The clients.
		/// </value>
		public IList<Client> Clients { get; set; }

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>
		/// The items.
		/// </value>
		public IList<Item> Items { get; set; }

		/// <summary>
		/// Gets or sets the employees.
		/// </summary>
		/// <value>
		/// The employees.
		/// </value>
		public IList<Employee> Employees { get; set; }
	}
}
