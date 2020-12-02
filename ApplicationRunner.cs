using System;
using Db4o_Sprawozdanie.DI;
using Db4o_Sprawozdanie.Operations;
using Db4o_Sprawozdanie.Operations.OperationsHandler;
using Db4o_Sprawozdanie.Operations.Params;
using Db4objects.Db4o;

namespace Db4o_Sprawozdanie
{
    public class ApplicationRunner
    {
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Select operation: ");
                Console.Write("1.Get cars based on query\n");
                Console.Write("2.Add car\n");
                var operation = Console.ReadKey();
                PerformOperation(operation);
            }
        }
        private void PerformOperation(ConsoleKeyInfo operation)
        {
            var factory = new ParamsFactory();
            var db = DependencyManager.Get<IObjectContainer>();
            switch (operation.KeyChar)
            {
                case '1':
                    var param = factory.GetParams<GetCarsOperationParams>();
                    var handler = new GetCarsOperationHandler(db);
                    var result = handler.PerformOperation(param);
                    break;
                case '2':
                    var newCarParam = factory.GetParams<NewCarParams>();
                    var newCarHandler = new AddCarOperationHandler(db);
                    newCarHandler.PerformOperation(newCarParam);
                    break;
            }
        }

       
    }
}
