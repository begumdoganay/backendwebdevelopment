using BookStore_Web_Application.Core.Exceptions;


namespace BookStore_Web_Application.Core.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = string.Empty;

        private Money() { }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        public static Money operator +(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new BusinessException("Cannot add different currencies");

            return new Money(left.Amount + right.Amount, left.Currency);
        }
    }
}
