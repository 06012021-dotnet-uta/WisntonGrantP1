using System;
using System.Collections.Generic;
using System.Linq;
using Database;

namespace BusLogic
{
	public class BusiLogic : IBusiLogic
	{

		//sizeOfLocations.Sort();

		 public masterContext Context;

		public BusiLogic(masterContext context) { this.Context = context; }
		//StoreLocation storeToGoTo = (from x in locationList where x.LocationId == userToLocationChange select x).FirstOrDefault();

		public List<Customer> GetUsers() 
		{
			 var CustomerList = Context.Customers.ToList();
			return CustomerList;
		}

}
	}

