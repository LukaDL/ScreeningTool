using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreeningTool.Models
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ScreeningUser")]
        public string? UserId { get; set; }
        public ScreeningUser? User { get; set; }
        [DisplayName("Do you have a fever of Fever of 37.8° or greater?")]
        public bool Question1 { get; set; }
        [DisplayName("Do you have a runny nose?")]
        public bool Question2 { get; set; }
        [DisplayName("Do you have a sore throat?")]
        public bool Question3 { get; set; }
        public bool Pass { get; set; }
        public DateTime LastResultTime { get; set; }

    }
}