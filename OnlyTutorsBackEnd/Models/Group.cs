namespace OnlyTutorsBackEnd.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }


        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

    }
}
