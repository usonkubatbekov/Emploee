using DataLayer.Entityes;

namespace PresentationLayer.Models
{
    public class EditSotrudnikDto
    {
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Position { get; set; }
    }
}
