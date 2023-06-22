namespace GeometryLibrary.Types;

public readonly struct Measure
{
    public double Value { get; }
    
    public Measure(double value) {
        ValidateValue(value);
        Value = value;
    }
    
    public int CompareTo(Measure other) => Value.CompareTo(other.Value);

    public bool Equals(Measure other) => Value.Equals(other.Value);

    public override bool Equals(object? obj) => obj is Measure other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();
    
    public static bool operator ==(Measure left, Measure right) => left.Equals(right);
    
    public static bool operator !=(Measure left, Measure right) => !(left == right);
    
    public static bool operator >(Measure left, Measure right) => left.CompareTo(right) > 0;

    public static bool operator <(Measure left, Measure right) => left.CompareTo(right) < 0;

    public static bool operator >=(Measure left, Measure right) => left.CompareTo(right) >= 0;

    public static bool operator <=(Measure left, Measure right) => left.CompareTo(right) <= 0;
    
    private static void ValidateValue(double value, string paramName = "") {
        switch (value) {
            case double.NegativeInfinity or double.PositiveInfinity:
                throw new ArgumentOutOfRangeException(paramName, "Value must be finite.");
            case double.NaN:
                throw new ArgumentOutOfRangeException(paramName, "Value must not be NaN.");
            case <= 0:
                throw new ArgumentOutOfRangeException(paramName, "Value must be positive.");
        }
    }
}