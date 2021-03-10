using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AthMan.Controllers
{
	/// <summary>
	/// Holds actions for Clients
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class ClientsController : Controller
	{
		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientsController"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public ClientsController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		/// <summary>
		/// The index action for Client.
		/// </summary>
		/// <returns>Returns the Index view.</returns>
		public IActionResult Index()
		{
			var clients = context.Clients.OrderBy(i => i.FirstName).ThenBy(i => i.LastName).ToList();
			return View(clients);
		}

		/// <summary>
		/// Returns the Details view for a Client
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Details view for a client</returns>
		[HttpGet]
		public IActionResult Details(int id)
		{
			var client = context.ClientPopulated(id);
			return View(client);
		}

		/// <summary>
		/// Returns the Edit view with a new Client.
		/// </summary>
		/// <returns>Edit view for a new client</returns>
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

		/// <summary>
		/// Returns the Edit view for a client
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Edit view for a client</returns>
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

		/// <summary>
		/// Add/Edits the specified client and returns back to index view.
		/// </summary>
		/// <param name="client">The client.</param>
		/// <returns>Redirect back to index view</returns>
		[HttpPost]
		public IActionResult Edit(Client client)
		{
			if (ModelState.IsValid)
			{
				if (client.ClientID == 0)
				{
					context.Clients.Add(client);
					TempData["ConfirmationMessage"] = $"You successfully added the client {client.FullName}.";
				}
				else
				{
					context.Clients.Update(client);
					TempData["ConfirmationMessage"] = $"You successfully updated the client {client.FullName}.";
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

		/// <summary>
		/// Returns the delete view for the client.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Delete view for a client</returns>
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var client = context.Clients.Find(id);
			return View(client);
		}

		/// <summary>
		/// Deletes client and redirects to index.
		/// </summary>
		/// <param name="client">The client.</param>
		/// <returns>Redirect to index view.</returns>
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
