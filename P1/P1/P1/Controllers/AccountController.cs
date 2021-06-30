using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusLogic;
using P1Database;
using Newtonsoft.Json;

namespace P1.Controllers
{
	public class AccountController : Controller
	{
		public IBusiLogic logic;
		P0Context context = new P0Context();
		// GET: AccountController

		//need to have a constructor with Ibusilogic in it
		public AccountController(IBusiLogic logic) 
		{
			this.logic = logic;
		}
		public ActionResult Index()
		{


			return View();
		}

		public ActionResult LogIn() 
		{ 


			return View(); 
		}
		public ActionResult LogInCheck(string fname, string lname) 
		{
			Customer User=	logic.LogInVerification(fname, lname);

			string statement = null;

			if (User != null)
			{
				statement = "We Logged you in";
				HttpContext.Session.SetString("Customer", JsonConvert.SerializeObject(User));

				Dictionary<int, Product> Kart = new Dictionary<int, Product>();

				HttpContext.Session.SetString("Kart", JsonConvert.SerializeObject(Kart));


			}
			else
			{
				statement = ("We Could Not Verify Your Account");
			}
			ViewBag.statement = statement;

			return View();
		}

		public ActionResult CreateAttempt(string fname, string lname) 
		{
			bool Validate= logic.CreateAccountVerification(fname, lname);
			string exist = null;
			if (Validate == true)
			{ exist = "Congrats on your account now go log in!";
				logic.CreateAccount(fname, lname);
				ViewBag.exist = exist;
			}
			else
			{  exist = "That person already has an account";
				ViewBag.exist = exist;
			}
			return View();
		}

		public ActionResult Users() {

			//var list = logic.GetUsers();
			
			
			return View(logic.GetUsers()); 
		}

		// GET: AccountController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: AccountController/Create
		public ActionResult Create()
		{


			return View();
		}

		// POST: AccountController/Create
	

		// GET: AccountController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: AccountController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AccountController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: AccountController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
