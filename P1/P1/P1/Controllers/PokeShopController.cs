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

			HttpContext.Session.SetString("store", JsonConvert.SerializeObject(shopStore));

			//Customer user = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Customer"));

			

			var productList = logic.CatChoice(shopStore);

		
			ViewBag.prod = productList;
			productList.Count();
		



				return View(productList);
		}

		public ActionResult CatChoice(string cat) 
		{
			var store = JsonConvert.DeserializeObject<StoreLocation>(HttpContext.Session.GetString("store"));

			var product1List = logic.ProChoice(cat,store.LocationId);


			
			

			return View(product1List);
		}

		public ActionResult Choice(string name) 
		{
			var store = JsonConvert.DeserializeObject<StoreLocation>(HttpContext.Session.GetString("store"));

			var inven = logic.InventoryChoice(store, name);
			var prod = logic.SpecificProductChoice(store, name);

			ViewBag.prod = prod;

				 HttpContext.Session.SetString("inven", JsonConvert.SerializeObject(inven));
			HttpContext.Session.SetString("prod", JsonConvert.SerializeObject(prod));


			return View(inven);

			//var invenprod = from x in inven 
			//				join y in prod on  
			
		}
		

	}
}
