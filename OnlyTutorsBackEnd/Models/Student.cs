using System.Text.RegularExpressions;

namespace OnlyTutorsBackEnd.Models
{
    public class Student : User
    {
        public string HighestEducationLevel { get; set; }
        
        public int GroupId { get; set; }
        public Group Group{ get; set; }
    }
}
