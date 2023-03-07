namespace DataLayer.Entities
{
    public class Employee : Person
    {
        public string Position { get; set; }
        public List<Child> Children { get; set; } = new List<Child>();
    }
}
