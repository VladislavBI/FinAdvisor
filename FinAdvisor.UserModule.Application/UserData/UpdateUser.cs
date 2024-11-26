namespace FinAdvisor.UserModule.Application.UserData;

public static class UpdateUser
{
    public record Command(Guid Id, string Name, int Age) : IRequest<Result<bool>>;

    public class UpdateUserHandler: IRequestHandler<Command, Result<bool>>
    {
        public Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}