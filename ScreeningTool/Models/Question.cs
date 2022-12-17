using System.ComponentModel.DataAnnotations;

namespace ScreeningTool.Models
{
    public class Question
    {
        
        [Key]
        public int Id { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public string Image { get; set; }
    }
}
