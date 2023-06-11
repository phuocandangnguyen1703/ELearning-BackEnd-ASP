using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
        public partial class CourseMix
        {

            public CourseMix()
            {

            }

            public int ID { get; set; }
            public string CourseName { get; set; }
            public string TypeName { get; set; }
            public string StatusName { get; set; }
            public string AuthorName { get; set; }
            public int? ReviewStar { get; set; }
            public int EnrollmentCount { get; set; }
            public string LevelName { get; set; }
            public string LanguageName { get; set; }
            public string CourseImage { get; set; }
            public int CourseFee { get; set; }
            public string Description { get; set; }
            public string Tags { get; set; }
            public DateTime Create_at { get; set; }
            public DateTime Update_at { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }

        }
}
