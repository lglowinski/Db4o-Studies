using System.Linq;
using System.Reflection;

namespace Db4o_Sprawozdanie.Operations
{
    class RequestDispatcher : IRequestDispatcher
    {
        public void Send<TOperationParams>(TOperationParams operationParams) where TOperationParams : IOperationParams
        {
            var handlerType = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.GetInterfaces().Contains(typeof(IOperationHandler<TOperationParams>))).FirstOrDefault();
            var handler = DI.DependencyManager.Get(handlerType);
            (handler as IOperationHandler<TOperationParams>).PerformOperation(operationParams);
        }

        public TResponse Send<TOperationParams, TResponse>(TOperationParams operationParams)
            where TOperationParams : IOperationParams
            where TResponse : IOperationResult
        {
            var handlerType = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.GetInterfaces().Contains(typeof(IOperationHandler<TOperationParams, TResponse>))).FirstOrDefault();
            var handler = DI.DependencyManager.Get(handlerType);
            return (handler as IOperationHandler<TOperationParams, TResponse>).PerformOperation(operationParams);
        }

        
    }
}
