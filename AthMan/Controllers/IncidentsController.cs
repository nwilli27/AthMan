using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AthMan.Controllers
{
	public class IncidentsController : Controller
	{

		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		public IncidentsController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		public IActionResult Index()
		{
			return RedirectToAction("List", "Incidents");
		}

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

		[HttpGet]
		public IActionResult Details(int id)
		{
			var incident = context.IncidentPopulated(id);
			return View(incident);
		}

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
