﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
    public partial class Learning
    {

        public Learning()
        {

        }

        public int ID { get; set; }

        public int LessonID { get; set; }
        public int UserID { get; set; }
        public TimeSpan LearnTime { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }


        public virtual User UserNavigation { get; set; }
        public virtual Lesson LessonNavigation { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
