using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AthMan.Controllers
{
	/// <summary>
	/// Holds actions for Incidents
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class IncidentsController : Controller
	{

		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="IncidentsController"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public IncidentsController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		/// <summary>
		/// The index action for Incident.
		/// </summary>
		/// <returns>Returns the Index view.</returns>
		public IActionResult Index()
		{
			return RedirectToAction("List", "Incidents");
		}

		/// <summary>
		/// Returns the List view for Incidents
		/// </summary>
		/// <param name="filter">The incidents filter.</param>
		/// <returns>List view for Incidents</returns>
		[Route("[controller]/{id?}")]
		public IActionResult List(string filter="all")
		{
			var listViewModel = new IncidentListViewModel()
			{
				Incidents = this.getFilteredIncidentList(filter).OrderBy(i => i.Title).ToList(),
				SelectedFilter = filter
			};

			return View(listViewModel);
		}

		/// <summary>
		/// Returns the Details view for a Incident
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Details view for a Incident</returns>
		[HttpGet]
		public IActionResult Details(int id)
		{
			var incident = context.IncidentPopulated(id);
			return View(incident);
		}

		/// <summary>
		/// Returns the Edit view with a new Incident.
		/// </summary>
		/// <returns>Edit view for a new Incident</returns>
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";

			var incidentViewModel = new IncidentViewModel()
			{
				Incident = new Incident(),
				Clients = context.Clients.ToList(),
				Employees = context.Employees.ToList(),
				Items = context.Items.ToList()
			};

			return View("Edit", incidentViewModel);
		}

		/// <summary>
		/// Returns the Edit view for a Incident
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Edit view for a Incident</returns>
		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";

			var incidentViewModel = new IncidentViewModel()
			{
				Incident = context.IncidentPopulated(id),
				Clients = context.Clients.ToList(),
				Employees = context.Employees.ToList(),
				Items = context.Items.ToList()
			};

			return View(incidentViewModel);
		}

		/// <summary>
		/// Add/Edits the specified Incident and returns back to index view.
		/// </summary>
		/// <param name="incident">The Incident.</param>
		/// <returns>Redirect back to index view</returns>
		[HttpPost]
		public IActionResult Edit(Incident incident)
		{
			if (ModelState.IsValid)
			{
				if (incident.IncidentID == 0)
				{
					context.Incidents.Add(incident);
					TempData["ConfirmationMessage"] = $"You successfully added the Incident.";
				}
				else
				{
					context.Incidents.Update(incident);
					TempData["ConfirmationMessage"] = $"You successfully updated the incident.";
				}
				context.SaveChanges();
				return RedirectToAction("Index", "Incidents");
			}
			else
			{
				ViewBag.Action = (incident.IncidentID == 0) ? "Add" : "Edit";

				var incidentViewModel = new IncidentViewModel()
				{
					Incident = incident,
					Clients = context.Clients.ToList(),
					Employees = context.Employees.ToList(),
					Items = context.Items.ToList()
				};

				return View(incidentViewModel);
			}
		}

		#endregion

		#region Private Helpers

		private List<Incident> getFilteredIncidentList(string filter)
		{
			var incidents = new List<Incident>();

			if (filter == "noemployee")
			{
				incidents = context.IncidentsPopulated.Where(i => i.Employee == null).ToList();
			}
			else if (filter == "nodateclosed")
			{
				incidents = context.IncidentsPopulated.Where(i => i.DateClosed == null).ToList();
			}
			else
			{
				incidents = context.IncidentsPopulated.ToList();
			}

			return incidents;
		}

		#endregion
	}
}
