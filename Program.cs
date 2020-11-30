using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db4o_Sprawozdanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationRunner = new ApplicationRunner();
            Db4oConnection.RegisterDb4oConnection(@"C:\myDb\carsDb.yap");
            applicationRunner.Run();
        }
    }
}
