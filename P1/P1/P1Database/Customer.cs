﻿using System;
using System.Collections.Generic;

#nullable disable

namespace P1Database
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
            OrderedProducts = new HashSet<OrderedProduct>();
        }

        public int CustomerId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? DefaultStore { get; set; }

        public virtual StoreLocation DefaultStoreNavigation { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}
