using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthMan.Controllers
{
	public class ClientsController : Controller
	{
		public IActionResult Index()
		{
			return View();
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
