using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Survey.Entities
{
    public class Ticket { 
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Form> Forms { get; set; }
    }
}