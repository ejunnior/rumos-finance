namespace Finance.Domain.Core
{
    public class ValueObject<TValueObject>
        where TValueObject : ValueObject<TValueObject>
    {
    }
}