using System;
using Survey.Enums;

namespace Survey.Entities
{
    public class Statistical
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int TicketId { get; set; }
        public QuizType QuizType { get; set; }
        public int Vote0 { get; set; }
        public int Vote1 { get; set; }
        public int Vote2 { get; set; }
        public int Vote3 { get; set; }
        public DateTime DateSubmited { get; set; }
        public int TotalQuiz { get; set; }
    }
}