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
		public IActionResult List(string id="all")
		{
			var listViewModel = new IncidentListViewModel()
			{
				Incidents = this.getFilteredIncidentList(id).OrderBy(i => i.Title).ToList(),
				SelectedFilter = id
			};

			return View(listViewModel);
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var item = context.Items.Find(id);
			return View(item);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Incident());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";

			var item = context.IncidentPopulated(id);
			
			return View(item);
		}

		[HttpPost]
		public IActionResult Edit(Incident incident)
		{
			if (ModelState.IsValid)
			{
				if (incident.IncidentID == 0)
				{
					context.Incidents.Add(incident);
				}
				else
				{
					context.Incidents.Update(incident);
				}
				context.SaveChanges();
				return RedirectToAction("Index", "Incidents");
			}
			else
			{
				ViewBag.Action = (incident.IncidentID == 0) ? "Add" : "Edit";
				return View(incident);
			}
		}

		#endregion

		#region Private Helpers

		private List<Incident> getFilteredIncidentList(string id)
		{
			var incidents = new List<Incident>();

			if (id == "all")
			{
				incidents = context.IncidentsPopulated.ToList();
			}
			else if (id == "noemployee")
			{
				incidents = context.IncidentsPopulated.Where(i => i.Employee == null).ToList();
			}
			else if (id == "nodateclosed")
			{
				incidents = context.IncidentsPopulated.Where(i => i.DateClosed == null).ToList();
			}

			return incidents;
		}

		#endregion
	}
}
