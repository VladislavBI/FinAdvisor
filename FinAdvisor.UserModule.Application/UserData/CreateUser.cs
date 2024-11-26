namespace FinAdvisor.UserModule.Application.UserData;

public static class CreateUser
{
    public record Command(string Name, int Age): IRequest<Result<CreateUserResponse>>;
    public record CreateUserResponse(Guid Id): IRequest<Result<CreateUserResponse>>;

    public class CreateUserHandler(IUserRepository repo): IRequestHandler<Command, Result<CreateUserResponse>>
    {
        public async Task<Result<CreateUserResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.Name, request.Age);

            var newId = await repo.CreateUserAsync(user);


            return new Result<CreateUserResponse>(new CreateUserResponse(newId));
        }
    }
}