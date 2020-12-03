using System;
using System.Collections.Generic;

namespace Db4o_Sprawozdanie.DI
{
    public static class DependencyManager
    {
        private static Dictionary<Type, object> _container = new Dictionary<Type, object>();
        public static void RegisterDependency<TDependencyType>(object dependency)
            => _container.Add(typeof(TDependencyType), dependency);

        public static TDependency Get<TDependency>()
            => (TDependency)_container[typeof(TDependency)];

        internal static void RegisterDependency(Type dependencyType, object dependencyObject)
        {
            _container.Add(dependencyType, dependencyObject);
        }

        internal static object Get(Type declaringType)
        {
            return _container[declaringType];
        }
    }
}
