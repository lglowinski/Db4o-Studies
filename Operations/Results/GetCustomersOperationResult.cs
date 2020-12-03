using System;
using System.Collections.Generic;
using Db4o_Sprawozdanie.Models;

namespace Db4o_Sprawozdanie.Operations.Results
{
    public class GetCustomersOperationResult : IOperationResult
    {
        public IEnumerable<Customer> Results { get; set; }

        public void LogResult()
        {
            int iterator = 1;
            foreach (var customer in Results)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine($"{iterator}. {customer}");
                Console.WriteLine("---------------------------");
                iterator++;
            }
        }
    }
}
