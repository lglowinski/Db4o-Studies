namespace Db4o_Sprawozdanie.Models
{
    public class Car : IModel
    {
        public Customer Customer;
        public Mechanic Mechanic;
        public string Brand;
        public string Model;
        public string CarIssue;
        public decimal FixPrice = 0;

        public override string ToString()
        {
            return $"Customer: {Customer}\nMechanic:{Mechanic}\nBrand: {Brand}\nModel: {Model}\nIssue: {CarIssue}\nFix price: {FixPrice}";
        }
    }
}
