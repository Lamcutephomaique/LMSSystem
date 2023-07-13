using LMSSystemAPI.Models;

namespace LMSSystemAPI.Dtos
{
    public class ExamDto
    {
        public int ExamId { get; set; }

        public string ExamName { get; set; }

        public int Time { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int CourseId { get; set; }

        public int TeacherId { get; set; }
    }
}
