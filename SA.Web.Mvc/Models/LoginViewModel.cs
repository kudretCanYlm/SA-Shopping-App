using System.ComponentModel.DataAnnotations;

namespace SA.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [Required]
        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;
    }
}
