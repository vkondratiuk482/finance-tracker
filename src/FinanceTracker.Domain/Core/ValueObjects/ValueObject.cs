namespace FinanceTracker.Domain.Core.ValueObjects;

/**
 * Source1: https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
 * Source2: https://github.com/kgrzybek/modular-monolith-with-ddd/blob/master/src/BuildingBlocks/Domain/ValueObject.cs
 */
public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(ValueObject valueObject)
    {
        return Equals((object)valueObject);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var target = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(target.GetEqualityComponents());
    }

    // TODO: figure out how this works and if there is a better approach
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public static bool operator ==(ValueObject source, ValueObject target)
    {
        return EqualsOperator(source, target);
    }

    public static bool operator !=(ValueObject source, ValueObject target)
    {
        return NotEqualsOperator(source, target);
    }

    private static bool EqualsOperator(ValueObject source, ValueObject target)
    {
        // TODO: additional research to figure out how does the XOR operator work here
        if (ReferenceEquals(source, null) ^ ReferenceEquals(target, null))
        {
            return false;
        }

        /**
         * We have to use || and not && since Value Object are equal if two different instances contains the same values for all of the properties/fields
         * We can add the ReferenceEquals check just to prevent additional value checks
         */
        return ReferenceEquals(source, target) || source.Equals(target);
    }

    private static bool NotEqualsOperator(ValueObject source, ValueObject target)
    {
        return !EqualsOperator(source, target);
    }
}
