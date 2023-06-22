using GeometryLibrary.Types;
using GeometryLibrary1.Abstractions;

namespace GeometryLibrary.Shapes;

public class Circle : Shape
{
    public Measure Radius { get; set; }

    public Circle(double radius)
    {
        Radius = new Measure(radius);
    }

    public override double CalculateArea() => Math.PI * Radius.Value * Radius.Value;
   
}