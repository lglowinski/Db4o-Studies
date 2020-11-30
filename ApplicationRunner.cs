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
                var operation = Console.ReadKey();
                PerformOperation(operation);
            }
        }
        private void PerformOperation(ConsoleKeyInfo operation)
        {
            var db = DependencyManager.Get<IObjectContainer>();
            switch (operation.KeyChar)
            {
                case '1':
                    var param = new GetCarsOperationParams();
                    var handler = new GetCarsOperationHandler(db);
                    var result = handler.PerformOperation(param);
                    break;
            }
        }
    }
}
