using Db4o_Sprawozdanie.Operations.Results;

namespace Db4o_Sprawozdanie.Operations.Params
{
    public class GetCarsOperationParams : IOperationParams
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string MechanicName { get; set; }
    }
}
