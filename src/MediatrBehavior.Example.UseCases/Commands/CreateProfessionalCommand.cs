using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace MediatrBehavior.Example.UseCases.Commands
{
    public class CreateProfessionalCommand : IRequest<string>, ICommand
    {
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public double? Salary { get; set; }
    }
}
