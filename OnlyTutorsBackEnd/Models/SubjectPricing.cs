﻿namespace OnlyTutorsBackEnd.Models
{
    public class SubjectPricing
    {
        public int Id { get; set; }
        public double Price { get; set; }


        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


    }
}
