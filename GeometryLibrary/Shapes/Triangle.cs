using GeometryLibrary.Interfaces;

namespace GeometryLibrary.Shapes;
public class Triangle : IShape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double CalculateArea()
    {
        var semiptr = (SideA + SideB + SideC) / 2;
        var square = Math.Sqrt(semiptr * (semiptr - SideA) * (semiptr - SideB) * (semiptr - SideC));
        
        return square;
    }

    public bool IsRightAngled()
    {
        double[] sides = { SideA, SideB, SideC };
        
        Array.Sort(sides); 

        var aSquare = sides[0] * sides[0];
        var bSquare = sides[1] * sides[1];
        var cSquare = sides[2] * sides[2];

        return Math.Abs(aSquare + bSquare - cSquare) < double.Epsilon;
    }
}