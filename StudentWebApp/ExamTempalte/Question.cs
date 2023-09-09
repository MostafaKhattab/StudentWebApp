namespace StudentWebApp.ExamTempalte
{
    public class Question
    {
        public string question { get; set; }
        public int QuestionId { get; set; }
        public string questiontype { get; set; }
        public string[]? choices { get; set; }

        public Question() { }

        public Question(string question, string questiontype, int questionid)
        {
            this.QuestionId = questionid;
            this.question = question;
            this.questiontype = questiontype;
        }
    }
}
