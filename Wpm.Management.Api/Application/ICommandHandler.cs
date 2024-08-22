namespace Wpm.Management.Api.Application;

public interface ICommandHandler<T>
{
    Task Handle(T command);
}