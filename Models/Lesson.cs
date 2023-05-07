using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
    public partial class Lesson
    {

        public Lesson()
        {

        }

        public int ID { get; set; }
        public int ChapterID { get; set; }
        public string LessonName { get; set; }
        public string LessonURL { get; set; }
        public int Duration { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }

        public virtual Learning LearningNavigation { get; set; }
        public virtual Chapter ChapterNavigation { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
