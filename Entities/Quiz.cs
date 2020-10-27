using System;
using System.ComponentModel.DataAnnotations;

namespace Survey.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        [StringLength(1000)]
        public string Title { get; set; }
        public int TicketId { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        [StringLength(1000)]
        public string ChoiceA { get; set; }
        [StringLength(1000)]
        public string ChoiceB { get; set; }
        [StringLength(1000)]
        public string ChoiceC { get; set; }
        [StringLength(1000)]
        public string ChoiceD { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}