namespace FinAdvisor.UserModule.Application.UserData;

public static class UserIndex
{
    public record Query(): IRequest<Result<IEnumerable<UserListResponse>>>;

    public record UserListResponse(Guid Id, string Name, int Age);

    public class GetUserDataHandler(IUserRepository repo): IRequestHandler<Query, Result<IEnumerable<UserListResponse>>>
    {
        public async Task<Result<IEnumerable<UserListResponse>>> Handle(Query query, CancellationToken cancellationToken)
        { 
           var users = await repo.GetAllUsersAsync();
           var usersMapped = users
               .Select(x => new UserListResponse(x.Id, x.Name, x.Age));

           return new Result<IEnumerable<UserListResponse>>(usersMapped);
        }
    }
}