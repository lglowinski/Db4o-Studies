using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db4o_Sprawozdanie.Models
{
    public class Customer : Person
    {
        public Customer() { }

        public string PhoneNumber { get; set; }
        public TitleEnum Title { get; set; }

        public override string ToString()
        {
            return Title.ToString() + ". " + FirstName + " " + LastName;
        }
    }
}
