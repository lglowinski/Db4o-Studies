using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db4o_Sprawozdanie.Operations.Params
{
    public static class ParamsFactory
    {
        public static IOperationParams GetParams(char paramsOption)
        {
            IOperationParams paramsToGet;
            switch (paramsOption)
            {
                case '1':
                    paramsToGet = new GetCarsOperationParams();
                    break;
                default:
                    throw new ArgumentException("Operation not found");
            }

            return paramsToGet;
        }
    }
}
