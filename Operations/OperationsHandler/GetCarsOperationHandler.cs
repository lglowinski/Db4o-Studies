using System.Collections.Generic;
using Db4o_Sprawozdanie.Models;
using Db4o_Sprawozdanie.Operations.Params;
using Db4o_Sprawozdanie.Operations.Results;
using Db4objects.Db4o;

namespace Db4o_Sprawozdanie.Operations.OperationsHandler
{
    public class GetCarsOperationHandler : IOperationHandler<GetCarsOperationParams, GetCarsOperationResult>
    {
        private readonly IObjectContainer _db;
        public GetCarsOperationHandler(IObjectContainer db)
        {
            _db = db;
        }

        public GetCarsOperationResult PerformOperation(GetCarsOperationParams operationParams)
        {
            var carTemplate = new Car()
            {
                Brand = operationParams.Brand,
                Model = operationParams.Model,
                Customer = new Customer() { FirstName = operationParams.CustomerFirstName, LastName = operationParams.CustomerLastName },
                Mechanic = new Mechanic() { FirstName = operationParams.MechanicName }
            };

            var result = _db.QueryByExample(carTemplate);
            return ConvertResult(result);
        }

        GetCarsOperationResult ConvertResult(IObjectSet objectSet)
        {
            var carsList = new List<Car>();
            foreach (var item in objectSet)
            {
                carsList.Add(item as Car);
            }

            return new GetCarsOperationResult() { Results = carsList };
        }

        GetCarsOperationResult IOperationHandler<GetCarsOperationParams, GetCarsOperationResult>.ConvertResult(IObjectSet objectSet)
        {
            return ConvertResult(objectSet);
        }
    }
}
