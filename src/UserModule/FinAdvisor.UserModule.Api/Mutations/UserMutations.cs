using static FinAdvisor.UserModule.Application.UserData.CreateUser;

namespace FinAdvisor.UserModule.Api.Mutations;

public class UserMutations
{
    public async Task<CreateUserResponse> CreateUser([Service] ISender sender, CreateUser.Command command)
    {
        var result = await sender.Send(command);

        return result.Match(s => s,
            ex => throw ex);
    }
}