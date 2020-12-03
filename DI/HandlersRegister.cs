using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Db4o_Sprawozdanie.Operations;

namespace Db4o_Sprawozdanie.DI
{
    public static class HandlersRegister
    {
        public static void RegisterHandlers()
        {
           foreach(var handlerType in Assembly.GetExecutingAssembly().GetTypes().Where(p => p.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(IOperationHandler<,>) || x.GetGenericTypeDefinition() == typeof(IOperationHandler<>)))))
           {
               
                var constructor = handlerType.GetConstructors();
                List<object> constructorParams = new List<object>();
                foreach(var constructorParam in constructor)
                {
                    foreach(var param in constructorParam.GetParameters())
                    {
                        constructorParams.Add(DependencyManager.Get(param.ParameterType));
                    }
                    
                }
                object[] dependencyList = new object[constructorParams.Count];
                for(int i = 0; i < dependencyList.Length; i++)
                {
                    dependencyList[i] = constructorParams[i];
                }
                var handlerObject = Activator.CreateInstance(handlerType, dependencyList);
                DependencyManager.RegisterDependency(handlerType, handlerObject);
           }
        }
    }
}
