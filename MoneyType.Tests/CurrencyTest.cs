using System;
using MoneyType;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CurrencyTest
    {
        [Test]
        public void Can_be_assigned_from_string()
        {
            Currency sek = "SEK";
            Assert.AreEqual("SEK", sek.IsoCode);
        }

        [Test]
        public void Can_be_casted_from_string()
        {
            var sek = (Currency) "SEK";
            Assert.AreEqual("SEK", sek.IsoCode);
        }

        [Test]
        public void Can_be_compared()
        {
            var sek1 = Currency.SEK;
            var sek2 = (Currency) "SEK";
            Assert.IsTrue(sek1.Equals(sek2));
        }

        [Test]
        public void Detects_invalid_iso_codes()
        {
            Assert.Throws<ArgumentException>(() => { var invalid = (Currency) "INVALID"; });
        }

        [Test]
        public void Has_instances()
        {
            Assert.IsInstanceOf<Currency>(Currency.DKK);
            Assert.IsInstanceOf<Currency>(Currency.EUR);
            Assert.IsInstanceOf<Currency>(Currency.NOK);
            Assert.IsInstanceOf<Currency>(Currency.SEK);
        }
    }
}