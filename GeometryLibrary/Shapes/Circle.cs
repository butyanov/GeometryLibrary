using GeometryLibrary.Types;
using GeometryLibrary1.Abstractions;

namespace GeometryLibrary.Shapes;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = new Measure(radius).Value;
    }

    public override double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
   
}