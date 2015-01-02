using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class FormModel
    {
        [Display(Name = "Email address")]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FileInput { get; set; }
        public bool CheckMeOut { get; set; }
    }
}