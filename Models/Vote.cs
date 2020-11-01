using System.Collections.Generic;
using System.Linq;
using Survey.Entities;
using Survey.Enums;

namespace Survey.Models
{
    public class Vote
    {
        public int[] LevelA { get; set; }
        public int[] LevelB { get; set; }
        public int[] LevelC { get; set; }
        public int[] LevelD { get; set; }
        public int[] LevelE { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public List<Quiz> Quizzes1 { get; set; }
        public List<Quiz> Quizzes2 { get; set; }
        public List<Quiz> Quizzes3 { get; set; }
        public List<Quiz> Quizzes4 { get; set; }
        public List<Quiz> Quizzes5 { get; set; }
    }
}