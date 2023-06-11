using System;
namespace ELearning.DTOs.Course
{
    public class TagDTO
    {
        public TagDTO()
        {
        }

        public int ID { get; set; }
        public int CourseID { get; set; }
        public string TagName { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}

