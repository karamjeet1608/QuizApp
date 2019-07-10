using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckITs
{
    public class Question
    {
        public string TopicId { get; set; }
        public string QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorectionAnswer { get; set; }
        public string QuestionCode { get; set; }
    }
}
