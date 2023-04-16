using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
    public partial class User
    {

        public User()
        {

        }

        public int ID { get; set; }
        public EROLE Role { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }

        //public virtual Role RoleNavigation { get; set; }


        [JsonIgnore]
        public virtual ICollection<Learning> Learnings { get; set; }
        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }
        [JsonIgnore]
        public virtual ICollection<Approval> Approvals { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
