namespace StudentWebApp.ExamTempalte
{
    public class Exam
    {
        public Question[]? Questions { get; set; }
        public  string ExamId { get; set; }
        public string ExamName {  get; set; }
        public Exam(string examid)
        {
            this.ExamId = examid;
        }
        public Exam() { }
    }
}
