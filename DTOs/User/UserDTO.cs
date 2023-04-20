using ELearning.Models;
using System;
namespace ELearning.DTOs.User
{
    public class UserDTO
    {
        public UserDTO()
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
    }
}

