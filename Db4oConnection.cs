using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Db4o_Sprawozdanie.DI;
using Db4objects.Db4o;

namespace Db4o_Sprawozdanie
{
    public static class Db4oConnection
    {
        public static void RegisterDb4oConnection(string fileLocation)
        {
            var config = Db4oFactory.Configure();
            config.MessageLevel(0);
            DependencyManager.RegisterDependency<IObjectContainer>(Db4oFactory.OpenFile(config, fileLocation));
        }
    }
}
