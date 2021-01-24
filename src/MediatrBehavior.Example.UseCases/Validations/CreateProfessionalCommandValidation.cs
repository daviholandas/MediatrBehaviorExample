using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatrBehavior.Example.UseCases.Commands;

namespace MediatrBehavior.Example.UseCases.Validations
{
    public class CreateProfessionalCommandValidation : AbstractValidator<CreateProfessionalCommand>
    {
        public CreateProfessionalCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("The name of professional can't be null or empty");
            RuleFor(c => c.HireDate)
                .GreaterThan(new DateTime(2019, 01, 01))
                .WithMessage("The hire date of professional can't be lass than 2019");
            RuleFor(c => c.Salary)
                .NotNull()
                .WithMessage("The salary of professional can't be null");
        }
    }
}
