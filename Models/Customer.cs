using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db4o_Sprawozdanie.Models
{
    public class Customer : Person
    {
        public string PhoneNumber;
        public TitleEnum Title;

        public override string ToString()
        {
            return Title.ToString() + ". " + FirstName + " " + LastName;
        }
    }
}
