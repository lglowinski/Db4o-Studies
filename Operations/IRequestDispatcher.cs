using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db4o_Sprawozdanie.Operations
{
    public interface IRequestDispatcher
    {
        TResponse Send<TResponse>(IOperationParams operationParams);
    }
}
