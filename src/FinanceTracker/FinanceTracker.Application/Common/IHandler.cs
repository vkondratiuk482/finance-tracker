namespace FinanceTracker.Application.Common;

public interface IHandler<TCommand, TResponse> where TCommand : ICommand
{
    TResponse Handle(TCommand command);
}
