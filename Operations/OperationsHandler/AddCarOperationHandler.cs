using System;
using Db4o_Sprawozdanie.Models;
using Db4o_Sprawozdanie.Operations.Params;
using Db4objects.Db4o;

namespace Db4o_Sprawozdanie.Operations.OperationsHandler
{
    public class AddCarOperationHandler : IOperationHandler<NewCarParams>
    {
        private readonly IObjectContainer _db;

        public AddCarOperationHandler(IObjectContainer db)
        {
            _db = db;
        }

        public void PerformOperation(NewCarParams operationParams)
        {
            var car = new Car()
            {
                Customer = operationParams.Customer,
                Mechanic = operationParams.Mechanic,
                Brand = operationParams.Brand,
                FixPrice = operationParams.FixPrice,
                CarIssue = operationParams.CarIssue,
                Model = operationParams.Model
            };

            _db.Store(car);
            _db.Commit();
            var r = _db.QueryByExample(car);
            Console.WriteLine(r.Count);
            foreach (var item in r)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------");
        }
    }
}
