namespace Db4o_Sprawozdanie.Models
{
    public class Mechanic : Person, IModel
    {
       public Mechanic() { }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
