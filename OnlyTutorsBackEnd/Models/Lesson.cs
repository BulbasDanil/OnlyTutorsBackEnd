﻿namespace OnlyTutorsBackEnd.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public int tutorid { get; set; }
        public int SubjectId { get; set; }
        public string Subjectname { get; set; }
    }
}
