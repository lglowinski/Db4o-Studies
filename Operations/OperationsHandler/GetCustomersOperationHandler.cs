using System.Collections.Generic;
using Db4o_Sprawozdanie.Models;
using Db4o_Sprawozdanie.Operations.Params;
using Db4o_Sprawozdanie.Operations.Results;
using Db4objects.Db4o;

namespace Db4o_Sprawozdanie.Operations.OperationsHandler
{
    public class GetCustomersOperationHandler : IOperationHandler<GetCustomersOperationParams, GetCustomersOperationResult>
    {
        private readonly IObjectContainer _db;

        public GetCustomersOperationHandler(IObjectContainer db)
        {
            _db = db;
        }

        public GetCustomersOperationResult PerformOperation(GetCustomersOperationParams operationParams)
        {
            var customer = new Customer()
            {
                FirstName = operationParams.FirstName,
                LastName = operationParams.LastName
            };

            var result = _db.QueryByExample(customer);

            return ConvertResult(result);
        }

        public GetCustomersOperationResult ConvertResult(IObjectSet objectSet)
        {
            var customers = new List<Customer>();
            foreach (var item in objectSet)
            {
                customers.Add(item as Customer);
            }

            return new GetCustomersOperationResult() { Results = customers };
        }
    }
}
