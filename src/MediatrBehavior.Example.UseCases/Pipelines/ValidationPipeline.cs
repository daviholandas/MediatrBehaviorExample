using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using MediatrBehavior.Example.UseCases.Commands;

namespace MediatrBehavior.Example.UseCases.Pipelines
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand
    {
        private readonly AbstractValidator<TRequest> _validator;

        public ValidationPipeline(AbstractValidator<TRequest> validator)
            => _validator = validator;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            ValidationResult validationResult;

            validationResult = _validator.Validate(request);

            if (validationResult.Errors.Any())
                return Task.FromResult((TResponse)Convert.ChangeType(validationResult.Errors.FirstOrDefault()?.ErrorMessage, typeof(TResponse)));


            return next();
        }
    }

}
