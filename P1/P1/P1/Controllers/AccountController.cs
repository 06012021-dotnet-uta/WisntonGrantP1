using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusLogic;
using Database;

namespace P1.Controllers
{
	public class AccountController : Controller
	{
		public IBusiLogic logic;
		// GET: AccountController
		public AccountController(IBusiLogic logic) 
		{
			this.logic = logic;
		}
		public ActionResult Index()
		{


			return View();
		}

		public ActionResult LogIn() { return View(); }

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
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
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
