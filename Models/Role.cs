using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



#nullable disable

namespace ELearning.Models
{
    public enum EROLE
    {
        CLIENT,
    }


    public partial class Role
    {
       
        public Role()
        {

        }

        public int ID { get; set; }
        public EROLE Type { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<User> Users { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
