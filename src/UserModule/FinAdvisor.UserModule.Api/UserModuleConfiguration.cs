using FinAdvisor.UserModule.Api.Mutations;
using FinAdvisor.UserModule.Api.Queries;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinAdvisor.UserModule.Api;

public static class UserModuleConfiguration
{
    public static IServiceCollection AddUserModule(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.UserData.UserIndex).Assembly));

        return services;
    }
    public static IRequestExecutorBuilder AddUserModuleSchema(this IRequestExecutorBuilder schemaBuilder)
    {
        return schemaBuilder
            .AddQueryType<UserDataQuery>()
            .AddMutationType<UserMutations>();
    }
}