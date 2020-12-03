using System.Collections.Generic;
using Db4o_Sprawozdanie.Models;
using Db4o_Sprawozdanie.Operations.Params;
using Db4o_Sprawozdanie.Operations.Results;
using Db4objects.Db4o;

namespace Db4o_Sprawozdanie.Operations.OperationsHandler
{
    public class GetMechanicsOperationHandler : IOperationHandler<GetMechanicsOperationParams, GetMechanicsOperationResult>
    {
        private readonly IObjectContainer _db;

        public GetMechanicsOperationHandler(IObjectContainer db)
        {
            _db = db;
        }

        public GetMechanicsOperationResult PerformOperation(GetMechanicsOperationParams operationParams)
        {
            var mechanic = new Mechanic 
            { 
                FirstName = operationParams.FirstName, 
                LastName = operationParams.LastName 
            };

            var result = _db.QueryByExample(mechanic);

            return ConvertResult(result);

        }

        public GetMechanicsOperationResult ConvertResult(IObjectSet objectSet)
        {
            var list = new List<Mechanic>();
            foreach(var item in objectSet)
            {
                list.Add(item as Mechanic);
            }

            return new GetMechanicsOperationResult { Results = list };
        }
    }
}
