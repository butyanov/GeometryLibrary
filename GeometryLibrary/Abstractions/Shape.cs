namespace GeometryLibrary1.Abstractions;

/// <summary>
///     General abstraction of shape.
/// </summary>
public abstract class Shape
{
    /// <summary>
    ///     Returns square of the shape.
    /// </summary>
    public abstract double CalculateArea();
    
    /// <summary>
    ///     Processes some validation rules for concrete shape, if needed.
    /// </summary>
    protected virtual void ValidateShape()
    {
        return;
    }
}