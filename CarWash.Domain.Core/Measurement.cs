using System;

namespace CarWash.Domain
{
    public class Measurement : ValueObject<Measurement>
    {
        private readonly decimal _value;
        private readonly string _code;

        public Measurement(decimal value, string code)
        {
            _value = value;
            _code = code;
        }

        public decimal Value
        {
            get { return _value; }
        }

        public string Code
        {
            get { return _code; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Measurement)) return false;

            var other = obj as Measurement;

            return AreCompatibleMeasurements(this, other) || _value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Measurement operator +(Measurement left, Measurement right)
        {
            if (!AreCompatibleMeasurements(left, right))
            {
                throw new ArgumentException("Measurement mismatch");
            }

            return new Measurement(left.Value + right.Value, left.Code);
        }

        public static Measurement operator -(Measurement left, Measurement right)
        {
            if (!AreCompatibleMeasurements(left, right))
            {
                throw new ArgumentException("Measurement mismatch");
            }

            return new Measurement(left.Value - right.Value, left.Code);
        }

        private static bool AreCompatibleMeasurements(Measurement left, Measurement right)
        {
            return left.Code.Equals(right.Code);
        }
    }
}