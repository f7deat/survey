using System.Collections.Generic;
using System.Linq;
using Survey.Entities;
using Survey.Enums;

namespace Survey.Models
{
    public class Vote
    {
        public List<IGrouping<QuizType, Quiz>> Quizzes { get; set; }
        public int[] Level1 { get; set; }
        public int[] Level2 { get; set; }
        public int[] Level3 { get; set; }
        public int[] Level4 { get; set; }
        public int[] Level5 { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; }
    }
}