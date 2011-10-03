using System;

namespace MoneyType
{
    public class Money : IEquatable<Money>
    {
        public Money(decimal amount, Currency currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException("currency");
            }

            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }

        #region IEquatable<Money> Members

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Amount == Amount && Equals(other.Currency, Currency);
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Money)) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode()*397) ^ Currency.GetHashCode();
            }
        }

        public static bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }
    }
}