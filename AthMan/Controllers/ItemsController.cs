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

		public IActionResult Index()
		{
			var items = context.Items.OrderBy(i => i.Name).ToList();
			return View(items);
		}

		public IActionResult Details()
		{
			return View();
		}

		public IActionResult Edit()
		{
			return View();
		}

		public IActionResult Delete()
		{
			return View();
		}
	}
}
