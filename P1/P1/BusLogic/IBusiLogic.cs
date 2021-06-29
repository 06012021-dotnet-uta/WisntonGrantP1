using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Threading.Tasks;

namespace BusLogic
{
	
	public interface IBusiLogic
	{
		public List<Customer> GetUsers();

	}
}
