using System;
using System.Collections.Generic;
using Db4o_Sprawozdanie.Models;

namespace Db4o_Sprawozdanie.Operations.Results
{
    public class GetMechanicsOperationResult : IOperationResult
    {
        public IEnumerable<Mechanic> Results { get; set; }
        public void LogResult()
        {
            int iterator = 1;
            foreach(var mechanic in Results)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine($"{iterator}. {mechanic}");
                Console.WriteLine("---------------------------");
                iterator++;
            }
        }
    }
}
