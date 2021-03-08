using System;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
	public class Incident
	{
		public int IncidentID { get; set; }

		public int ClientID { get; set; }     // foreign key property
		public Client Client { get; set; }  // navigation property

		public int ItemID { get; set; }     // foreign key property
		public Item Item { get; set; }   // navigation property

		public int? EmployeeID { get; set; }     // foreign key property - nullable
		public Employee Employee { get; set; }   // navigation property

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime DateOpened { get; set; } = DateTime.Now;

		public DateTime? DateClosed { get; set; } = null;
	}
}