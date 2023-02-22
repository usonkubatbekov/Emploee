namespace DataLayer.Entityes
{
    public class SotrudnikEntity
    {
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Position { get; set; }

        public List<ChildEntity> Children { get; set; } = new List<ChildEntity>();
    }
}
