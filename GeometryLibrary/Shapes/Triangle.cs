using GeometryLibrary.Types;
using GeometryLibrary1.Abstractions;

namespace GeometryLibrary.Shapes;
public sealed class Triangle : Shape
{
    private Lazy<Measure[]> SortedSidesFactory => new (SortSidesAscending);
    public Measure[] SortedSides => SortedSidesFactory.Value; 
    public Measure SideA { get; set; }
    public Measure SideB { get; set; }
    public Measure SideC { get; set; }
    

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA =  new Measure(sideA);
        SideB = new Measure(sideB);
        SideC = new Measure(sideC);
    }

    public override double CalculateArea()
    {
        var semiptr = (SideA.Value + SideB.Value + SideC.Value) / 2;
        var square = Math.Sqrt(semiptr * (semiptr - SideA.Value) * (semiptr - SideB.Value) * (semiptr - SideC.Value));
        
        return square;
    }

    public bool IsRightAngled(double epsilon = double.Epsilon)
    {
        var aSquare = SortedSides[0].Value * SortedSides[0].Value;
        var bSquare = SortedSides[1].Value * SortedSides[1].Value;
        var cSquare = SortedSides[2].Value * SortedSides[2].Value;

        return Math.Abs(aSquare + bSquare - cSquare) < epsilon;
    }

    private Measure[] SortSidesAscending() => new[] { SideA, SideB, SideC }.OrderBy(x => x.Value).ToArray();
}