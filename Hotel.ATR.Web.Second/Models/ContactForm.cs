using System.ComponentModel.DataAnnotations;

namespace Hotel.ATR.Web.Second.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage ="Укажите имя")]
        public string name { get; set; }

        [Required(ErrorMessage = "Укажите email")]
        [EmailAddress(ErrorMessage ="Email не корректный")]
        public string email { get; set; }

        public string message { get; set; }
    }
}
