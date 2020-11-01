using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Survey.Enums;

namespace Survey.Entities
{
    public class Ticket { 
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int DeparmentId { get; set; }
        public ETicketStatus Status { get; set; }
    }
}