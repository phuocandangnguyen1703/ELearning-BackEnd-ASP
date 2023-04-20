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
        public int AuthorID { get; set; }
        public int CourseTypeID { get; set; }
        public string CourseName { get; set; }
        public string CourseImage { get; set; }
        public int CourseFee { get; set; }
        public string Description { get; set; }
        public int CourseState { get; set; }
        public int Commission { get; set;}
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }


        [JsonIgnore]
        public virtual ICollection<Approval> Approvals { get; set; }
        [JsonIgnore]
        public virtual ICollection<Chapter> Chapters { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }

        [JsonIgnore]
        public virtual User AuthorNavigation { get; set; }
        [JsonIgnore]
        public virtual Require RequireNavigation { get; set; }
        [JsonIgnore]
        public virtual MainType MainTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual User UserNavigation { get; set; }
        [JsonIgnore]
        public virtual Lesson LessonNavigation { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
