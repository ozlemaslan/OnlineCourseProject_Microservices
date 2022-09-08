using System.ComponentModel;

namespace FreeCourse.Web.Models
{
    public class SigninInput
    {
        [DisplayName("Email Adresi")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("Beni hatırla")]
        public bool IsRemember { get; set; }
    }
}
