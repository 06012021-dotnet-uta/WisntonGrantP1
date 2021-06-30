using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P1Database;
using Microsoft.AspNetCore.Http;
using BusLogic;
using Newtonsoft.Json;

namespace P1.Controllers
{
	public class PokeShopController : Controller
	{
		public IBusiLogic logic;
		P0Context context = new P0Context();
		// GET: AccountController

		//need to have a constructor with Ibusilogic in it
		public PokeShopController(IBusiLogic logic)
		{
			this.logic = logic;
		}
		public ActionResult Index()
		{
			var locationList = logic.GetLocation();
			return View(locationList);
		}

		public ActionResult ShopChoice(string store) 
		{
			var shopStore = logic.PickaStore(store);

			ViewBag.store = shopStore;

			HttpContext.Session.SetString("store", JsonConvert.SerializeObject(shopStore));

			Customer user = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Customer"));

			ViewBag.user = user;


			return View();
		}

	}
}
