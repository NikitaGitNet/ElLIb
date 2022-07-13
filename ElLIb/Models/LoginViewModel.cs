using System.ComponentModel.DataAnnotations;

namespace ElLIb.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Логин")]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        [Display(Name = "Логин")]
        public string Password { get; set; }
        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
