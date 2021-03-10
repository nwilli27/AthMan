using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
	/// <summary>
	/// Holds actions for home page.
    /// 
    /// Author: Nolan Williams
    /// Date:   3/9/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class HomeController : Controller
    {

		/// <summary>
		/// Returns Home page index view.
		/// </summary>
		/// <returns>Returns index view for home.</returns>
		public IActionResult Index()
        {
            return View();
        }
    }
}