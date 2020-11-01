using System;
using System.ComponentModel.DataAnnotations;
using Survey.Enums;

namespace Survey.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}