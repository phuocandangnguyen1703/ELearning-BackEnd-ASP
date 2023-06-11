using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
    public partial class Course
    {

        public Course()
        {

        }

        public int ID { get; set; }
        public int CourseTypeID { get; set; }
        public int CourseAuthorID { get; set; }
        public int CourseLevelID { get; set; }
        public int CourseLanguageID { get; set; }
        public int ApprovalStatus { get; set; }
        public string CourseName { get; set; }
        public string CourseImage { get; set; }
        public int CourseFee { get; set; }
        public string Description { get; set; }
        public int CourseStatus { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
