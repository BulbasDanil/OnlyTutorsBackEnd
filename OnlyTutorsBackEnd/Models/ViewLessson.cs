namespace OnlyTutorsBackEnd.Models
{
    public class ViewLessson : Lesson
    {
        public string Subjectname { get; set; }
        public List<Student> Students { get; }
    }
}
