namespace CarWash.Domain
{
    public static class MeasurementExtension
    {
        public static Measurement Kgs(this int value)
        {
            return new Measurement(value, "Kg");
        }

        public static Measurement Units(this int value)
        {
            return new Measurement(value, "Units");
        }

        public static Measurement Pieces(this int value)
        {
            return new Measurement(value, "Pieces");;
        }
    }
}