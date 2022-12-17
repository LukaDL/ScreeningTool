using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ScreeningTool.Models
{
    public class ScreeningUser : IdentityUser
    {
        /*
        [Key]
        public int Id { get; set; }
        */
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Confirmed { get; set; }

    }
}