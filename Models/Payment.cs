//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;

//#nullable disable

//namespace ELearning.Models
//{
//    public partial class Payment
//    {

//        public Payment()
//        {

//        }

//        public int ID { get; set; }

//        public int UserID { get; set; }
//        public int EnrollmentID { get; set; }

//        [JsonIgnore]
//        public virtual ICollection<Lesson> Lessons { get; set; }

//        [JsonIgnore]
//        public virtual Course CourseNavigation { get; set; }

//        public override string ToString()
//        {
//            return JsonConvert.SerializeObject(this);
//        }

//    }
//}
