using DMF_Services.DTOs.UserDetails;
using FluentValidation;

namespace DMF_Services.Validators
{
    public class CreateUserDetailValidator : AbstractValidator<CreateUserDetailDto>
    {
        public CreateUserDetailValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

            RuleFor(x => x.Mobile)
                .NotEmpty()
                .MaximumLength(20)
                .Matches(@"^\+?[0-9]{8,15}$")
                .WithMessage("Invalid mobile number");
        }
    }
}
