using GeometryLibrary.Types;
using GeometryLibrary1.Abstractions;

namespace GeometryLibrary.Shapes;
public sealed class Triangle : Shape
{
    private Lazy<Measure[]> SortedSidesFactory => new (SortSidesAscending);
    
    /// <summary>
    ///     Sorted sides of the triangle.
    /// </summary>
    public Measure[] SortedSides => SortedSidesFactory.Value; 
    public Measure SideA { get; set; }
    public Measure SideB { get; set; }
    public Measure SideC { get; set; }
    
    /// <summary>
    ///     Create triangle instance with specified sides.
    /// </summary>
    /// <param name="sideA">First side of the triangle.</param>
    /// <param name="sideB">Second side of the triangle.</param>
    /// <param name="sideC">Third side of the triangle.</param>
    /// <exception cref="ArgumentException">Thrown if triangle inequality mismatch detected (it is impossible to create triangle).</exception>
    public Triangle(Measure sideA, Measure sideB, Measure sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        ValidateShape();
    }

    public override double CalculateArea()
    {
        var semiptr = (SideA.Value + SideB.Value + SideC.Value) / 2;
        var square = Math.Sqrt(semiptr * (semiptr - SideA.Value) * (semiptr - SideB.Value) * (semiptr - SideC.Value));
        
        return square;
    }

    /// <summary>
    ///     Determines if the triangle is right.
    /// </summary>
    public bool IsRightAngled(double epsilon = double.Epsilon)
    {
        var aSquare = SortedSides[0].Value * SortedSides[0].Value;
        var bSquare = SortedSides[1].Value * SortedSides[1].Value;
        var cSquare = SortedSides[2].Value * SortedSides[2].Value;

        return Math.Abs(aSquare + bSquare - cSquare) < epsilon;
    }
    
    /// <summary>
    ///     Triangle inequality match validation.
    /// </summary>
    protected override void ValidateShape()
    {
        if (!ValidateTriangleSides(SideA.Value, SideB.Value, SideC.Value) ||
            !ValidateTriangleSides(SideB.Value, SideC.Value, SideA.Value) ||
            !ValidateTriangleSides(SideC.Value, SideA.Value, SideB.Value)) {
            throw new ArgumentException("Invalid measure values for triangle");
        }
    }
    
    private bool ValidateTriangleSides(double firstSideMeasureValue, double secondSideMeasureValue, double thirdSideMeasureValue) 
        => firstSideMeasureValue + secondSideMeasureValue > thirdSideMeasureValue;

    private Measure[] SortSidesAscending() => new[] { SideA, SideB, SideC }.OrderBy(x => x.Value).ToArray();
}