using System;
using System.ComponentModel.DataAnnotations;

namespace Survey.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public int ChoiceA { get; set; }
        public int ChoiceB { get; set; }
        public int ChoiceC { get; set; }
        public int ChoiceD { get; set; }
        public DateTime DateSubmited { get; set; }
        public int TotalForm { get; set; }
    }
}