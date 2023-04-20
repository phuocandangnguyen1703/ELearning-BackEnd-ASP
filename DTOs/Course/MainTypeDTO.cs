using System;
namespace ELearning.DTOs.Course
{
    public class MainTypeDTO
    {
        public MainTypeDTO()
        {
        }
        public int ID { get; set; }
        public string TypeName { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}

