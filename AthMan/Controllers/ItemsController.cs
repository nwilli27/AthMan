using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AthMan.Controllers
{
	/// <summary>
	/// Holds actions for Items
	/// 
	/// Author: Nolan Williams
	/// Date:	3/9/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class ItemsController : Controller
	{
		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemsController"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public ItemsController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		/// <summary>
		/// The index action for Items.
		/// </summary>
		/// <returns>Returns the Index view.</returns>
		public IActionResult Index()
		{
			var items = context.Items.OrderBy(i => i.Name).ToList();
			return View(items);
		}

		/// <summary>
		/// Returns the Details view for a Item
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Details view for a Item</returns>
		[HttpGet]
		public IActionResult Details(int id)
		{
			var item = context.Items.Find(id);
			return View(item);
		}

		/// <summary>
		/// Returns the Edit view with a new Item.
		/// </summary>
		/// <returns>Edit view for a new Item</returns>
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Item());
		}

		/// <summary>
		/// Returns the Edit view for a Item
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Edit view for a Item</returns>
		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";

			var item = context.Items.Find(id);

			return View(item);
		}

		/// <summary>
		/// Add/Edits the specified Item and returns back to index view.
		/// </summary>
		/// <param name="item">The Item.</param>
		/// <returns>Redirect back to index Item</returns>
		[HttpPost]
		public IActionResult Edit(Item item)
		{
			if (ModelState.IsValid)
			{
				if (item.ItemID == 0)
				{
					context.Items.Add(item);
					TempData["ConfirmationMessage"] = $"You successfully added the item {item.Name}.";
				}
				else
				{
					context.Items.Update(item);
					TempData["ConfirmationMessage"] = $"You successfully updated the item {item.Name}.";
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

		/// <summary>
		/// Returns the delete view for the Item.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Delete view for a Item</returns>
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var item = context.Items.Find(id);
			return View(item);
		}

		/// <summary>
		/// Deletes Item and redirects to index.
		/// </summary>
		/// <param name="item">The Item.</param>
		/// <returns>Redirect to index view.</returns>
		[HttpPost]
		public IActionResult Delete(Item item)
		{
			context.Items.Remove(item);
			context.SaveChanges();
			return RedirectToAction("Index", "Items");
		}

		#endregion
	}
}
