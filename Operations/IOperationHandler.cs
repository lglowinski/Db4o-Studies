using Db4objects.Db4o;

namespace Db4o_Sprawozdanie.Operations
{
    public interface IOperationHandler<in TOperationParams> where TOperationParams : IOperationParams
    {
        void PerformOperation(TOperationParams operationParams);
    }

    public interface IOperationHandler<in TOperationParams, TResult> where TOperationParams : IOperationParams where TResult : IOperationResult
    {
        TResult PerformOperation(TOperationParams operationParams);
        TResult ConvertResult(IObjectSet objectSet);
    }
}
