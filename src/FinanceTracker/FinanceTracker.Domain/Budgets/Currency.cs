namespace FinanceTracker.Domain.Budgets;

public sealed class Currency
{
    public Guid Id { get; set; }

    public string Iso4217Code { get; set; }

    public int Iso4217Num { get; set; }

    private readonly List<Source> _sources;

    public IReadOnlyList<Source> Sources => _sources.AsReadOnly();

    private Currency()
    {
        _sources = new List<Source>();
    }
}
