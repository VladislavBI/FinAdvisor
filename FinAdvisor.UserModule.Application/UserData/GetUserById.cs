namespace FinAdvisor.UserModule.Application.UserData;

public static class GetUserById
{
    public record Query(Guid Id): IRequest<Result<UserDetailedResponse>>;
    public record UserDetailedResponse(Guid Id, string Name, int Age);

    public class GetUserByIdHandler(IUserRepository repo): IRequestHandler<Query, Result<UserDetailedResponse>>
    {
        public async Task<Result<UserDetailedResponse>> Handle(Query query, CancellationToken cancellationToken)
        {
           var user = await repo.GetUserByIdAsync(query.Id);
           
           if (user is null)
           {
               return new Result<UserDetailedResponse>(new UserNotFoundException(query.Id));
           }

           var userMapped = new UserDetailedResponse(user.Id, user.Name, user.Age);
           return await Task.FromResult(userMapped);
        }
    }
}