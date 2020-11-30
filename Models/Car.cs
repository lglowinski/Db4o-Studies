using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db4o_Sprawozdanie.Models
{
    public class Car
    {
        public Customer Customer;
        public Mechanic Mechanic;
        public string Brand;
        public string Model;
        public string CarIssue;
        public decimal FixPrice = 0;


    }
}
