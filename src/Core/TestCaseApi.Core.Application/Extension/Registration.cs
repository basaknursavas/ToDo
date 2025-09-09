using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace TestCaseApi.Core.Application.Extension;

public static class Registration
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(assm);

        return services;
    }
}
