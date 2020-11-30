using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Db4o_Sprawozdanie.Operations;

namespace Db4o_Sprawozdanie.DI
{
    public static class HandlersRegister
    {
        public static void RegisterHandlers()
        {
           foreach(var handlerType in Assembly.GetExecutingAssembly().GetTypes().Where(p => p.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IOperationHandler<,>))))
           {
                var handlerObject = Activator.CreateInstance(handlerType);
                //DependencyManager.RegisterDependency<>(handlerObject);
           }
        }
    }
}
