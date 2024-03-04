using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Q_AManagement.Models
{
    public class QuestionPaperWithSubmission
    {
        public QuestionPaper QuestionPaper { get; set; }
        public Submission Submission { get; set; }
    }
}