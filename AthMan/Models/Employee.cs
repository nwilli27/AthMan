﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
	public class Employee
	{
		public int EmployeeID { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }
	}
}
