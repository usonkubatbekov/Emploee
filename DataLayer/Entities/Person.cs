namespace DataLayer.Entities
{
    public abstract class Person : IdBase
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }
    }
}
