using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P1Database;
using System.Threading.Tasks;

namespace BusLogic
{
	
	public interface IBusiLogic
	{
		public List<Customer> GetUsers();

		public Customer LogInVerification(string fname, string lname);

		public bool CreateAccountVerification(string fname, string lname);

		public void CreateAccount(string fname, string lname);

		public List<StoreLocation> GetLocation();

		public StoreLocation PickaStore(string store);

		public List<string> CatChoice(StoreLocation store);

		public Inventory InventoryChoice(StoreLocation store,string name);

		public List<Product> ProChoice(string cat, int storeID);

		public Product SpecificProductChoice(StoreLocation store, string name);

	}
}
