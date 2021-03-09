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

		[HttpGet]
		public IActionResult Details()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Employee());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var employee = context.Employees.Find(id);
			return View(employee);
		}

		[HttpPost]
		public IActionResult Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				if (employee.EmployeeID == 0)
				{
					context.Employees.Add(employee);
				}
				else
				{
					context.Employees.Update(employee);
				}
				context.SaveChanges();
				return RedirectToAction("Index", "Employees");
			}
			else
			{
				ViewBag.Action = (employee.EmployeeID == 0) ? "Add" : "Edit";
				return View(employee);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var employee = context.Employees.Find(id);
			return View(employee);
		}

		[HttpPost]
		public IActionResult Delete(Employee employee)
		{
			context.Employees.Remove(employee);
			context.SaveChanges();
			return RedirectToAction("Index", "Employees");
		}

		#endregion
	}
}
