using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1.Controllers
{
	public class PokeShopController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
