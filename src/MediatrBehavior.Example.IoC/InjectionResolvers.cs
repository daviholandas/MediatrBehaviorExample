using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MediatR;
using FluentValidation;
using MediatrBehavior.Example.UseCases.Pipelines;

namespace MediatrBehavior.Example.IoC
{
    public static class InjectionResolvers
    {
        public static IServiceCollection AppInjectionResolvers(this IServiceCollection services)
        {
            var appDomain = AppDomain.CurrentDomain;
            
            //Injection MediatR Implementation
            var useCaseAssembly = appDomain.Load("MediatrBehavior.Example.UseCases");
            services.AddMediatR(useCaseAssembly);

            //Register Pipelines MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            //Injection FluentValidation
            var validators = useCaseAssembly.ExportedTypes
                .Where(t => t.IsClass && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

            foreach (var validate in validators)
                services.AddTransient(validate.BaseType, validate);

            
            return services;
        }
    }
}
