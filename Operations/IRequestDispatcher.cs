namespace Db4o_Sprawozdanie.Operations
{
    public interface IRequestDispatcher
    {
        void Send<TOperationParams>(TOperationParams operationParams) where TOperationParams : IOperationParams;
        TResponse Send<TOperationParams, TResponse>(TOperationParams operationParams) where TOperationParams : IOperationParams where TResponse : IOperationResult;
    }
}
