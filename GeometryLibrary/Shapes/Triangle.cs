using GeometryLibrary.Types;
using GeometryLibrary1.Abstractions;

namespace GeometryLibrary.Shapes;
public sealed class Triangle : Shape
{
    private Lazy<double[]> SortedSidesFactory => new (SortSidesAscending);
    public double[] SortedSides => SortedSidesFactory.Value; 
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
    

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA =  new Measure(sideA).Value;
        SideB = new Measure(sideB).Value;
        SideC = new Measure(sideC).Value;
    }

    public override double CalculateArea()
    {
        var semiptr = (SideA + SideB + SideC) / 2;
        var square = Math.Sqrt(semiptr * (semiptr - SideA) * (semiptr - SideB) * (semiptr - SideC));
        
        return square;
    }

    public bool IsRightAngled(double epsilon = double.Epsilon)
    {
        var aSquare = SortedSides[0] * SortedSides[0];
        var bSquare = SortedSides[1] * SortedSides[1];
        var cSquare = SortedSides[2] * SortedSides[2];

        return Math.Abs(aSquare + bSquare - cSquare) < epsilon;
    }

    private double[] SortSidesAscending() => new[] { SideA, SideB, SideC }.OrderBy(x => x).ToArray();
}