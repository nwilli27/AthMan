using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Controllers
{
	/// <summary>
	/// Holds actions for Employees
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class EmployeesController : Controller
	{
		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeesController"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public EmployeesController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		/// <summary>
		/// The index action for Employee.
		/// </summary>
		/// <returns>Returns the Index view.</returns>
		public IActionResult Index()
		{
			var employees = context.Employees.OrderBy(i => i.Name).ToList();
			return View(employees);
		}

		/// <summary>
		/// Returns the Details view for a Employee
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Details view for a Employee</returns>
		[HttpGet]
		public IActionResult Details(int id)
		{
			var employee = context.Employees.Find(id);
			return View(employee);
		}

		/// <summary>
		/// Returns the Edit view with a new Employee.
		/// </summary>
		/// <returns>Edit view for a new Employee</returns>
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Employee());
		}

		/// <summary>
		/// Returns the Edit view for a Employee
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Edit view for a Employee</returns>
		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var employee = context.Employees.Find(id);
			return View(employee);
		}

		/// <summary>
		/// Add/Edits the specified Employee and returns back to index view.
		/// </summary>
		/// <param name="employee">The Employee.</param>
		/// <returns>Redirect back to index view</returns>
		[HttpPost]
		public IActionResult Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				if (employee.EmployeeID == 0)
				{
					TempData["ConfirmationMessage"] = $"You successfully added the employee {employee.Name}.";
					context.Employees.Add(employee);
				}
				else
				{
					TempData["ConfirmationMessage"] = $"You successfully updated the employee {employee.Name}.";
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

		/// <summary>
		/// Returns the delete view for the Employee.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Delete view for a Employee</returns>
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var employee = context.Employees.Find(id);
			return View(employee);
		}

		/// <summary>
		/// Deletes Employee and redirects to index.
		/// </summary>
		/// <param name="employee">The Employee.</param>
		/// <returns>Redirect to index view.</returns>
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
