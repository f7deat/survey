using System;
using System.ComponentModel.DataAnnotations;
using Survey.Enums;

namespace Survey.Entities
{
    public class User {
        [Key]
        public string Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public bool Gender { get; set; }
        [StringLength(200)]
        public string Rank { get; set; }
        [StringLength(200)]
        public string Department { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}