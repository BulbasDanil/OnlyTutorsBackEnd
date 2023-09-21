namespace OnlyTutorsBackEnd.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Descpription { get; set; }
        public TimeOnly TimeOnly { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }  

    }
}
