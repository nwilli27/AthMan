using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AthMan.Controllers
{
	public class ClientsController : Controller
	{
		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		public ClientsController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		public IActionResult Index()
		{
			var clients = context.Clients.OrderBy(i => i.FirstName).ThenBy(i => i.LastName).ToList();
			return View(clients);
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var client = context.ClientPopulated(id);
			return View(client);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";

			var model = new ClientViewModel()
			{
				Countries = context.Countries.OrderBy(c => c.Name).ToList(),
				Client = new Client()
			};

			return View("Edit", model);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";

			var model = new ClientViewModel()
			{
				Countries = context.Countries.OrderBy(c => c.Name).ToList(),
				Client = context.Clients.Find(id)
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(Client client)
		{
			if (ModelState.IsValid)
			{
				if (client.ClientID == 0)
				{
					context.Clients.Add(client);
				}
				else
				{
					context.Clients.Update(client);
				}
				context.SaveChanges();
				return RedirectToAction("Index", "Clients");
			}
			else
			{
				ViewBag.Action = (client.ClientID == 0) ? "Add" : "Edit";

				var model = new ClientViewModel()
				{
					Countries = context.Countries.OrderBy(c => c.Name).ToList(),
					Client = client
				};

				return View(model);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var client = context.Clients.Find(id);
			return View(client);
		}

		[HttpPost]
		public IActionResult Delete(Client client)
		{
			context.Clients.Remove(client);
			context.SaveChanges();
			return RedirectToAction("Index", "Clients");
		}

		#endregion
	}
}
