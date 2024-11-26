
namespace FinAdvisor.UserModule.Application.UserData.EventHandler;

internal class UserCreatedEventHandler: INotificationHandler<UserCreatedEvent>
{
    public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        var a = notification.User.Id;
        return Task.CompletedTask;
    }
}