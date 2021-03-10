using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Models
{
	/// <summary>
	/// Holds data for the Incidents list view
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	public class IncidentListViewModel
	{

		/// <summary>
		/// Gets or sets the incidents.
		/// </summary>
		/// <value>
		/// The incidents.
		/// </value>
		public IList<Incident> Incidents { get; set; }

		/// <summary>
		/// Gets or sets the selected filter.
		/// </summary>
		/// <value>
		/// The selected filter.
		/// </value>
		public string SelectedFilter { get; set; }

		/// <summary>
		/// Checks the active filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>active if [filter] == SelectedFilter</returns>
		public string CheckActiveFilter(string filter) => filter == SelectedFilter ? "active" : "";
	}
}
