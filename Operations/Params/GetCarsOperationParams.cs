using Db4o_Sprawozdanie.Operations.Results;

namespace Db4o_Sprawozdanie.Operations.Params
{
    public class GetCarsOperationParams : IOperationParams
    {
        public string Brand;
        public string Model;
        public string CustomerFirstName;
        public string CustomerLastName;
        public string MechanicName;
    }
}
