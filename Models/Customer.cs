namespace Db4o_Sprawozdanie.Models
{
    public class Customer : Person, IModel
    {
        public Customer() { }

        public string PhoneNumber { get; set; }
        public TitleEnum Title { get; set; }

        public override string ToString()
        {
            return Title.ToString() + ". " + FirstName + " " + LastName;
        }
    }
}
