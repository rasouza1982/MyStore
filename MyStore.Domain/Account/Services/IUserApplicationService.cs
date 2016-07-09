using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Entities;

namespace MyStore.Domain.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
    }
}