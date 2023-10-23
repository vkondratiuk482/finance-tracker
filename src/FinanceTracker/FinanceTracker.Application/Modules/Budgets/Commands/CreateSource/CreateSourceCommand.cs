using MediatR;
using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Application.Modules.Budgets.Commands.CreateSource;

public class CreateSourceCommand : IRequest<Guid>
{
    public int Amount { get; set; }
    
    public SourceTypes Type { get; set; }
    
    public SourceFrequencies Frequency { get; set; }
    
    public string Description { get; set; }
    
    public Guid CategoryId { get; set; }
}
