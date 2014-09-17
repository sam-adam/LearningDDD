using System;
using System.Globalization;

namespace CarWash.Domain
{
    /// <summary>
    /// Represents money used in real world application
    /// </summary>
    public class Money : ValueObject<Money>
    {
        private readonly decimal _value;
        private readonly string _currencyCode;

        public Money(decimal value, string currencyCode)
        {
            _value = value;
            _currencyCode = currencyCode;
        }

        public Money(decimal value, NumberFormatInfo currencyFormat)
        {
            _value = value;
            _currencyCode = currencyFormat.CurrencySymbol;
        }

        public Money(decimal value)
        {
            _value = value;
            _currencyCode = DefaultCurrencyFormat.CurrencySymbol;
        }

        public static readonly NumberFormatInfo DefaultCurrencyFormat = CultureInfo.CurrentCulture.NumberFormat;
        public static readonly Money Zero = new Money(0);

        public static Money IDR(decimal value)
        {
            return new Money(value, "IDR");
        }

        public static Money USD(decimal value)
        {
            return new Money(value, "USD");
        }

        public decimal Value { get { return _value; } }

        public string CurrencyCode { get { return _currencyCode; } }

        public override bool Equals(object obj)
        {
            if (!(obj is Money)) return false;

            var other = obj as Money;

            return AreCompatibleCurrencies(this, other) || _value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Money operator +(Money left, Money right)
        {
            if (!AreCompatibleCurrencies(left, right))
            {
                throw new ArgumentException("Currency mismatch");
            }

            return new Money(left.Value + right.Value, left.CurrencyCode);
        }

        public static Money operator -(Money left, Money right)
        {
            if (!AreCompatibleCurrencies(left, right))
            {
                throw new ArgumentException("Currency mismatch");
            }

            return new Money(left.Value - right.Value, left.CurrencyCode);
        }

        public Money MultiplyBy(decimal multiplier)
        {
            return new Money(Value * multiplier, CurrencyCode);
        }

        public Money MultiplyBy(int multiplier)
        {
            return MultiplyBy((decimal) multiplier);
        }

        public Money MultiplyBy(double multiplier)
        {
            return MultiplyBy((decimal)multiplier);
        }

        private static bool AreCompatibleCurrencies(Money left, Money right)
        {
            return left.CurrencyCode.Equals(right.CurrencyCode);
        }
    }
}