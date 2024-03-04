using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Q_AManagement.Models
{
    public class AllTableJoin
    {
        public Question Questions { get; set; }
        public Submission Submissions { get; set; }
        public QuestionPaper QuestionPapers { get; set; }
        public User Users { get; set; }
        public int Score { get; set; }
    }
}