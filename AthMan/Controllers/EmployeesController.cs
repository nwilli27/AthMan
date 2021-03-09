using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Controllers
{
	public class EmployeesController : Controller
	{
		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		public EmployeesController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		public IActionResult Index()
		{
			var employees = context.Employees.OrderBy(i => i.Name).ToList();
			return View(employees);
		}

		public IActionResult Details()
		{
			return View();
		}

		public IActionResult Edit()
		{
			return View();
		}

		public IActionResult Delete()
		{
			return View();
		}

		#endregion
	}
}
