namespace FinanceTracker.Application.Common;

public interface IHandler<TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command);
}
