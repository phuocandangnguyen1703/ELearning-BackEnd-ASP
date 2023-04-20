using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
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
        public string Biography { get; set; }
        public DateTime? Birthday { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Job { get; set; }
        public string Avt_img { get; set; }
        public string Background_img { get; set; }
        public string Email_verified_at { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }


        //public virtual Role RoleNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Learning> Learnings { get; set; }
        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }
        [JsonIgnore]
        public virtual ICollection<Approval> Approvals { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
        /*        [JsonIgnore]
        public virtual ICollection<Course> CourseUserNavigations { get; set; } = new List<Course>();*/

        /*  [JsonIgnore]
          public virtual ICollection<Payment> Payment { get; set; }

          [JsonIgnore]
          public virtual ICollection<Enrollments> Enrollments { get; set; }

          [JsonIgnore]
          public virtual ICollection<Comments> Comments { get; set; }

          [JsonIgnore]
          public virtual ICollection<Notifications> Notifications { get; set; }*/


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
