using static FinAdvisor.UserModule.Application.UserData.GetUserById;
using static FinAdvisor.UserModule.Application.UserData.UserIndex;

namespace FinAdvisor.UserModule.Api.Queries;

public class UserDataQuery
{
    [GraphQLName("Users")]
    public async Task<IEnumerable<UserListResponse>> GetUsers([Service] ISender sender)
    {
        var result = await sender.Send(new UserIndex.Query());
        return result.Match(
            s => s,
            ex => throw ex);
    }

    [GraphQLName("User")]
    public async Task<UserDetailedResponse> GetUserById([Service] ISender sender, Guid id)
    {
        var result = await sender.Send(new GetUserById.Query(id));

        return result.Match(
            s => s,
            ex => throw ex);
    }
}