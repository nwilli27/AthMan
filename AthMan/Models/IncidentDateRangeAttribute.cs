using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Models
{
	/// <summary>
	/// Custom validation for Incident open/closed check
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	/// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
	public class IncidentDateRangeAttribute : ValidationAttribute
	{
		/// <summary>
		/// Returns true if incident closed is greater than the open date; otherwise false.
		/// </summary>
		/// <param name="value">The value of the object to validate.</param>
		/// <returns>
		/// Returns true if the incident closed is greater than the open; otherwise false
		/// </returns>
		public override bool IsValid(object value)
		{
			Incident incident = value as Incident;

			if (incident?.DateClosed != null)
			{
				return incident.DateClosed >= incident.DateOpened;
			}

			return true;
		}
	}
}
