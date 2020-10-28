using System.Collections.Generic;
using System.Linq;
using Survey.Entities;
using Survey.Enums;

namespace Survey.Models
{
    public class Vote
    {
        public List<IGrouping<QuizType, Quiz>> Quizzes { get; set; }
        public int[] LevelA { get; set; }
        public int[] LevelB { get; set; }
        public int[] LevelC { get; set; }
        public int[] LevelD { get; set; }
        public int[] LevelE { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; }
    }
}