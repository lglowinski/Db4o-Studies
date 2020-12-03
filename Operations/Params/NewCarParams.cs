using Db4o_Sprawozdanie.Models;

namespace Db4o_Sprawozdanie.Operations.Params
{
    public class NewCarParams : IOperationParams
    {
        public Customer Customer { get; set; }
        public Mechanic Mechanic { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarIssue { get; set; }
        public decimal FixPrice { get; set; } = 0;
    }
}
