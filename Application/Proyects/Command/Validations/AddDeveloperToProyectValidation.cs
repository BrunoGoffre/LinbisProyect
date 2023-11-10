using FluentValidation;

namespace Application.Proyects.Command.Validations
{
    public class AddDevelopresToProyectValidator : AbstractValidator<AddDevelopersToProyectCommand>
    {
        public AddDevelopresToProyectValidator()
        {
            RuleFor(v => v.Developer.Id).NotEmpty().WithMessage("Must have Id");
            RuleFor(v => v.Developer.Name).NotEmpty().WithMessage("Must have name");
            RuleFor(v => v.Developer.costByDay).NotEmpty().WithMessage("Must have costByDay and can be 0");
            RuleFor(v => v.Developer.AddedDate).NotEmpty().WithMessage("Must have AddedDate and can be 0");
        }
    }
}