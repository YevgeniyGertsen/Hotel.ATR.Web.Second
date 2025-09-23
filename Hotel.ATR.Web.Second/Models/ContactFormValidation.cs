using FluentValidation;

namespace Hotel.ATR.Web.Second.Models
{
    public class ContactFormValidation : AbstractValidator<ContactForm>
    {
        public ContactFormValidation()
        {
            RuleFor(r => r.name)
                 .NotEmpty()
                 .WithMessage("Поле должно быть заполнено");
        }
    }
}
