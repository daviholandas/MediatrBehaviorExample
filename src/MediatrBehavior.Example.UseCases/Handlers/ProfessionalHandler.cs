using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrBehavior.Example.Core.Models;
using MediatrBehavior.Example.UseCases.Commands;

namespace MediatrBehavior.Example.UseCases.Handlers
{
    public class ProfessionalHandler : IRequestHandler<CreateProfessionalCommand, string>
    {
        public Task<string> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
        {
            Professional professional = new(request.Name, request.HireDate, request.Salary);

            return Task.FromResult( $"The professional {professional.Name} has created succeeded");
        }
    }
}
