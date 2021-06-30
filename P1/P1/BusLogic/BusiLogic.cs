using System;
using System.Collections.Generic;
using System.Linq;
using P1Database;

namespace BusLogic
{
	public class BusiLogic : IBusiLogic
	{

		//sizeOfLocations.Sort();

		public P0Context Context = new P0Context();

		public BusiLogic(P0Context context) { this.Context = context; }
		//StoreLocation storeToGoTo = (from x in locationList where x.LocationId == userToLocationChange select x).FirstOrDefault();
		/// <summary>
		/// Gets a list of users
		/// </summary>
		/// <returns>list of customers</returns>
		public List<Customer> GetUsers()
		{
			var CustomerList = Context.Customers.ToList();
			return CustomerList;
		}
		/// <summary>
		/// checks if person is in Db
		/// </summary>
		/// <param name="fname">takes there name</param>
		/// <param name="lname">takes there other name</param>
		/// <returns></returns>
		public Customer LogInVerification(string fname, string lname)
		{
			try
			{
				var checkInformationRaw = (from c in Context.Customers
										   where c.Lname == lname && c.Fname == fname
										   select c).FirstOrDefault();
				//returnCustomer = checkInformationRaw.FirstOrDefault();

				if (checkInformationRaw == null)
				{ return null; }
				else
				{
					return checkInformationRaw;
				}
			}
			catch (Exception)
			{
				return null;
			}

		}
		/// <summary>
		/// verifies if person is in db on second look this is a dup and can be mergered
		/// </summary>
		/// <param name="fname"></param>
		/// <param name="lname"></param>
		/// <returns></returns>
		public bool CreateAccountVerification(string fname, string lname)
		{
			try
			{
				var checkInformationRaw = (from c in Context.Customers
										   where c.Lname == lname && c.Fname == fname
										   select c).FirstOrDefault();
				//returnCustomer = checkInformationRaw.FirstOrDefault();

				if (checkInformationRaw == null)
				{ return true; }
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}

		}
		/// <summary>
		/// creates a new acount
		/// </summary>
		/// <param name="fname">takes first name</param>
		/// <param name="lname">takes last name</param>
		public void CreateAccount(string fname, string lname) 
		{

			var newcust = new P1Database.Customer();

			newcust.Fname = fname;
			newcust.Lname = lname;
			//newcust.DefaultStore = 5;
			Context.Add(newcust);
			Context.SaveChanges();

			//Console.WriteLine($"\tHello {FName} {LName} Congratulations on creating an acount!");


		}

		/// <summary>
		/// get's the pokeLocation
		/// </summary>
		/// <returns></returns>
		public List<StoreLocation> GetLocation() 
		{
			var LocationList = Context.StoreLocations.ToList();

			return LocationList;
		}

		/// <summary>
		/// chooses the store the user picked
		/// </summary>
		/// <param name="store"></param>
		/// <returns></returns>
		public StoreLocation PickaStore(string store) 
		{
			var reStore = (from x in Context.StoreLocations
						  where x.LocationName == store
						  select x).FirstOrDefault();

			return reStore;
		}

		/// <summary>
		/// chooses catagories for the user
		/// </summary>
		/// <param name="store"></param>
		/// <returns></returns>
		public List<string> CatChoice(StoreLocation store) 
		{
			var storeProduct = (from x in Context.Products
								from y in Context.Inventories
								where y.LocationId == store.LocationId && x.ProductId == y.ProductId
								orderby y.ProductId
								select x.ProductDescription).Distinct().ToList();

			

			return storeProduct;
		}

		public Inventory InventoryChoice(StoreLocation store,string name)
		{
			var storeProduct = (from x in Context.Products
								from y in Context.Inventories
								where y.LocationId == store.LocationId 
								&& x.ProductId == y.ProductId
								&& x.ProductName == name
								select y).FirstOrDefault();

			return storeProduct;
		}
		public Product SpecificProductChoice(StoreLocation store, string name)
		{
			var storeProduct = (from x in Context.Products
								from y in Context.Inventories
								where y.LocationId == store.LocationId
								&& x.ProductId == y.ProductId
								&& x.ProductName == name
								select x).FirstOrDefault();

			return storeProduct;
		}
			public List<Product> ProChoice(string cat, int storeID) 
		{
			var store1Product = (from x in Context.Products
								from y in Context.Inventories
								where y.LocationId == storeID
								&& x.ProductId == y.ProductId
								&& x.ProductDescription == cat
								select x).ToList();

			return store1Product;
		}

	}
}

