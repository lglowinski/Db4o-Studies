using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4o_Sprawozdanie.Operations;

namespace Db4o_Sprawozdanie.DI
{
    public static class DependencyManager
    {
        private static Dictionary<Type, object> _container = new Dictionary<Type, object>();
        public static void RegisterDependency<TDependencyType>(object dependency) 
            => _container.Add(typeof(TDependencyType), dependency);

        public static TDependency Get<TDependency>() 
            => (TDependency)_container[typeof(TDependency)];
    }
}
