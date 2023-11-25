namespace OnlyTutorsBackEnd.Models
{
    public class Tutor : User
    {
        public int userId { get; set; }
        public string Descprtion { get; set; }
        public string Experience { get; set; }
    }
}
