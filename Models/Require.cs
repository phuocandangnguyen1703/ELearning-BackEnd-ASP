using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
    public partial class Require
    {

        public Require()
        {

        }

        public int ID { get; set; }

        public int CourseID { get; set; }
        public string Content { get; set; }


        [JsonIgnore]
        public virtual Course CourseNavigation { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
