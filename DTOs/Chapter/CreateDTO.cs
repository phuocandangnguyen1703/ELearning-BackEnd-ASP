using System;
namespace ELearning.DTOs.Chapter
{
    public class CreateDTO
    {
        public CreateDTO()
        {
        }

        public int ID { get; set; }
        public int CourseID { get; set; }
        public string ChapterName { get; set; }
    }
}

