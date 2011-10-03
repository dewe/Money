using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyType
{
    public class Currency : IEquatable<Currency>
    {
        private static readonly HashSet<string> Whitelist = new HashSet<string> {"DKK", "EUR", "NOK", "SEK"};

        // ReSharper disable InconsistentNaming
        public static readonly Currency DKK = new Currency("DKK");
        public static readonly Currency EUR = new Currency("EUR");
        public static readonly Currency NOK = new Currency("NOK");
        public static readonly Currency SEK = new Currency("SEK");
        // ReSharper restore InconsistentNaming

        private Currency(string isocode)
        {
            if (NotOnWhiteList(isocode))
            {
                throw new ArgumentException("Invalid ISO Currency Code");
            }

            IsoCode = isocode;
        }

        public string IsoCode { get; private set; }

        #region IEquatable<Currency> Members

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.IsoCode, IsoCode);
        }

        #endregion

        private bool NotOnWhiteList(string isocode)
        {
            return !Whitelist.Contains<string>(isocode);
        }

        public static implicit operator Currency(string isocode)
        {
            return new Currency(isocode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Currency)) return false;
            return Equals((Currency) obj);
        }

        public override int GetHashCode()
        {
            return IsoCode.GetHashCode();
        }

        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }
    }
}