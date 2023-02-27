namespace DataLayer.Entities
{
    public class Child : Person
    {

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}
