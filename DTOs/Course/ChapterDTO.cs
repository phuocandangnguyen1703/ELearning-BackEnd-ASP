using System;
namespace ELearning.DTOs.Course
{
    public class ChapterDTO
    {
        public ChapterDTO()
        {
        }
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string ChapterName { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}

