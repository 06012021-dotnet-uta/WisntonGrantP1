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

		public List<Customer> GetUsers()
		{
			var CustomerList = Context.Customers.ToList();
			return CustomerList;
		}

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

		public List<StoreLocation> GetLocation() 
		{
			var LocationList = Context.StoreLocations.ToList();

			return LocationList;
		}

		public StoreLocation PickaStore(string store) 
		{
			var reStore = (from x in Context.StoreLocations
						  where x.LocationName == store
						  select x).FirstOrDefault();

			return reStore;
		}

		public List<Product> ProductChoice(StoreLocation store) 
		{
			var storeProduct = (from x in Context.Products
								from y in Context.Inventories
								where y.LocationId == store.LocationId && x.ProductId == y.ProductId
								select x).ToList();

			return storeProduct;
		}

		public List<Inventory> InventoryChoice(StoreLocation store)
		{
			var storeProduct = (from x in Context.Products
								from y in Context.Inventories
								where y.LocationId == store.LocationId && x.ProductId == y.ProductId
								select y).ToList();

			return storeProduct;
		}

	}
}

