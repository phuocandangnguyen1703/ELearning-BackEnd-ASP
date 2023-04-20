using System;
namespace ELearning.DTOs.Course
{
    public class LessonDTO
    {
        public LessonDTO()
        {
        }
        public int ID { get; set; }
        public int ChapterID { get; set; }
        public string LessonName { get; set; }
        public string LessonURL { get; set; }
        public TimeSpan Duration { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}

