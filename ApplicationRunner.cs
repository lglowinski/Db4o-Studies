using System;
using Db4o_Sprawozdanie.Operations;
using Db4o_Sprawozdanie.Operations.Params;
using Db4o_Sprawozdanie.Operations.Results;

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
                Console.WriteLine("1.Get cars based on query");
                Console.WriteLine("2.Add car");
                Console.WriteLine("3.Get customers based on query");
                Console.WriteLine("4.Get mechanics based on query");
                var operation = Console.ReadKey();
                PerformOperation(operation);
            }
        }
        private void PerformOperation(ConsoleKeyInfo operation)
        {
            var factory = new ParamsFactory();
            IRequestDispatcher dispatcher = new RequestDispatcher();
            IOperationResult result = null;
            switch (operation.KeyChar)
            {
                case '1':
                    var param = factory.GetParams<GetCarsOperationParams>();
                    result = dispatcher.Send<GetCarsOperationParams, GetCarsOperationResult>(param);
                    break;
                case '2':
                    var newCarParam = factory.GetParams<NewCarParams>();
                    dispatcher.Send(newCarParam);
                    break;
                case '3':
                    var customerParam = factory.GetParams<GetCustomersOperationParams>();
                    result = dispatcher.Send<GetCustomersOperationParams, GetCustomersOperationResult>(customerParam);
                    break;
                case '4':
                    var mechanicParam = factory.GetParams<GetMechanicsOperationParams>();
                    result = dispatcher.Send<GetMechanicsOperationParams, GetMechanicsOperationResult>(mechanicParam);
                    break;
            }

            if (result != null)
            {
                Console.WriteLine("Results:");
                result.LogResult();
                Console.WriteLine("-------------------");
            }
        }


    }
}
