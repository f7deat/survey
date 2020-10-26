using System;
using System.ComponentModel.DataAnnotations;
using Survey.Enums;

namespace Survey.Entities
{
    public class User {
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public bool Gender { get; set; }
        [StringLength(1000)]
        public string Bio { get; set; }
        public UserType UserType { get; set; }
    }
}