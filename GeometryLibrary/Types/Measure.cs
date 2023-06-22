namespace GeometryLibrary.Types;

public readonly struct Measure
{
    /// <summary>
    ///     Value of the measure.
    /// </summary>
    public double Value { get; }
    
    /// <summary>
    ///     Creates measure instance with background double value validation.
    /// </summary>
    /// <param name="value">Wrapped measure value.</param>
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
    
    
    /// <summary>
    ///     Validates value to ensure it is positive, not Nan and finite.
    /// </summary>
    /// <param name="value">Value to validate.</param>
    /// <param name="paramName">Name of param which is not valid and will be shown in exception.</param>
    /// <exception cref="ArgumentOutOfRangeException">In case value is not valid, exact reason is being shown.</exception>
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