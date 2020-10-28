using System;
using System.ComponentModel.DataAnnotations;
using Survey.Enums;

namespace Survey.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        [StringLength(2000)]
        public string Title { get; set; }
        public int TicketId { get; set; }
        public QuizType QuizType { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}