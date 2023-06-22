using GeometryLibrary.Types;
using GeometryLibrary1.Abstractions;

namespace GeometryLibrary.Shapes;

public class Circle : Shape
{
    /// <summary>
    ///     Stores radius of circle.
    /// </summary>
    public Measure Radius { get; set; }
    
    // <summary>
    ///     Create circle with radius.
    /// </summary>
    /// <param name="radius">Radius of the circle.</param>
    public Circle(Measure radius)
    {
        Radius = radius;
    }

    public override double CalculateArea() => Math.PI * Radius.Value * Radius.Value;
   
}