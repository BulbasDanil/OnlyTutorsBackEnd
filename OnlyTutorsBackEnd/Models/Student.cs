using System.Text.RegularExpressions;

namespace OnlyTutorsBackEnd.Models
{
    public class Student : User
    {
        public int studentId { get; set; }
        public int userId { get; set; }
        public string HighestLevelOfEducation { get; set; }

    }
}
