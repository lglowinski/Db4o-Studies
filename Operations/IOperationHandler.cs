using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db4o_Sprawozdanie.Operations
{
    interface IOperationHandler<in TOperationParams> where TOperationParams : IOperationParams
    {
        void PerformOperation(TOperationParams operationParams);
    }

    interface IOperationHandler<in TOperationParams, TResult> where TOperationParams : IOperationParams where TResult : IOperationResult
    {
        TResult PerformOperation(TOperationParams operationParams);
    }
}
