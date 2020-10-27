using System;
using System.ComponentModel.DataAnnotations;

namespace Survey.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        [StringLength(2000)]
        public string Title { get; set; }
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}