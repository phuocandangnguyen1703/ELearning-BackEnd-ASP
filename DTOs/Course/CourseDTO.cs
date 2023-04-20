using System;
namespace ELearning.DTOs.Course
{
    public class CourseDTO
    {
        public CourseDTO()
        {
        }
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public int CourseTypeID { get; set; }
        public string CourseName { get; set; }
        public string CourseImage { get; set; }
        public int CourseFee { get; set; }
        public string Description { get; set; }
        public int CourseState { get; set; }
        public int Commission { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }

    }
}

