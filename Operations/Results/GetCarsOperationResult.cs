using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4o_Sprawozdanie.Models;

namespace Db4o_Sprawozdanie.Operations.Results
{
    public class GetCarsOperationResult : IOperationResult
    {
        public IEnumerable<Car> Cars;
    }
}
