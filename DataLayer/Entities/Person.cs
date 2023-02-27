namespace DataLayer.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }
    }
}
