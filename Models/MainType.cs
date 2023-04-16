using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
    public partial class MainType
    {

        public MainType()
        {

        }

        public int ID { get; set; }


        public string TypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
