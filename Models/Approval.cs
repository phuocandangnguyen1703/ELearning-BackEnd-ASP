using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace ELearning.Models
{
    public partial class Approval
    {

        public Approval()
        {

        }

        public int ID { get; set; }

        public int CourseID { get; set; }
        public int UserID { get; set; }
        public DateTime ApproveTime { get; set; }
        public bool IsAccepted { get; set; }
        public bool Reason { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }

        public virtual User UserNavigation { get; set; }
        public virtual Course CourseNavigation { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
