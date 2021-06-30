﻿using System;
using System.Collections.Generic;

#nullable disable

namespace P1Database
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
            Customers = new HashSet<Customer>();
            Inventories = new HashSet<Inventory>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
