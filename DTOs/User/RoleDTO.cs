using ELearning.Models;
using System;
namespace ELearning.DTOs.User
{
    public class RoleDTO
    {
        public RoleDTO()
        {
        }

        public int ID { get; set; }
        public EROLE Type { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int Is_active { get; set; }
        public int Is_deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }

    }
}

