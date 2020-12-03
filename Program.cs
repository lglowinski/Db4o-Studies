using System;
using Db4o_Sprawozdanie.DI;
using Db4objects.Db4o;

namespace Db4o_Sprawozdanie
{
    class Program
    {
        static void Main()
        {
            var applicationRunner = new ApplicationRunner();
            Db4oConnection.RegisterDb4oConnection($@"{Environment.CurrentDirectory}\carsDb.yap");
            HandlersRegister.RegisterHandlers();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            applicationRunner.Run();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("Application has closed");
            var _db = DependencyManager.Get<IObjectContainer>();
            _db.Close();
        }
    }
}
