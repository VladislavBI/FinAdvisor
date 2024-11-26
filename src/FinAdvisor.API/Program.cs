using FinAdvisor.UserModule.Api;
using FinAdvisor.UserModule.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddUserModule();

builder.Services
    .AddGraphQLServer()
    .ModifyOptions(opt => opt.UseXmlDocumentation = true)
    .AddUserModuleSchema();

builder.Services
    .AddUserModule()
    .AddUserModuleInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();
