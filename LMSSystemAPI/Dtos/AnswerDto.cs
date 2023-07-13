namespace LMSSystemAPI.Dtos
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }
        public string AnswerName { get; set; }
        public int QuestionId { get; set; }
        public int Status { get; set; }
    }
}
