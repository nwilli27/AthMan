using AthMan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Controllers
{
	public class ItemsController : Controller
	{
		#region Members

		private AthManContext context { get; set; }

		#endregion

		#region Construction

		public ItemsController(AthManContext context)
		{
			this.context = context;
		}

		#endregion

		#region Actions

		public IActionResult Index()
		{
			var items = context.Items.OrderBy(i => i.Name).ToList();
			return View(items);
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

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var item = context.Items.Find(id);
			return View(item);
		}

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
