using System.Collections.Generic;
using Survey.Entities;

namespace Survey.Models
{
    public class Vote
    {
        public List<Quiz> Quizzes { get; set; }
        public int[] Level { get; set; }
    }
}