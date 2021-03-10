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

		[Route("[controller]s/{id?}")]
		public IActionResult List(string id="all")
		{
			List<Incident> incidents = new List<Incident>();

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

			incidents = incidents.OrderBy(i => i.Title).ToList();

			return View(incidents);
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
			return View("Edit", new Item());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";

			var item = context.Items.Find(id);

			return View(item);
		}

		[HttpPost]
		public IActionResult Edit(Item item)
		{
			if (ModelState.IsValid)
			{
				if (item.ItemID == 0)
				{
					context.Items.Add(item);
				}
				else
				{
					context.Items.Update(item);
				}
				context.SaveChanges();
				return RedirectToAction("Index", "Items");
			}
			else
			{
				ViewBag.Action = (item.ItemID == 0) ? "Add" : "Edit";
				return View(item);
			}
		}

		#endregion
	}
}
