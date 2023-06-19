using GeometryLibrary.Shapes;
using GeometryLibrary1.Abstractions;

namespace GeometryLibrary.UnitTests;

public class TriangleTests
{
    [Theory]
    [InlineData(3, 4, 5, 6)]  // Проверка площади прямоугольного треугольника
    [InlineData(5, 5, 5, 10.825317547305483)]  // Проверка площади равностороннего треугольника
    [InlineData(5, 7, 8, 17.320508075688775)]  // Проверка площади произвольного треугольника
    public void CalculateArea_ShouldReturnCorrectArea(double sideA, double sideB, double sideC, double expectedArea)
    {
        Shape triangle = new Triangle(sideA, sideB, sideC);
        
        var actualArea = ShapeCalcUtility.CalculateArea(triangle);
        
        Assert.Equal(expectedArea, actualArea, precision: 10);
    }
    
    [Theory]
    [InlineData(3, 4, 5, true)]      // прямоугольный треугольник
    [InlineData(5, 12, 13, true)]    // прямоугольный треугольник
    [InlineData(4, 4, 4, false)]      // равносторонний треугольник, но не прямоугольный
    [InlineData(8, 15, 17, true)]    // прямоугольный треугольник
    [InlineData(7, 7, 10, false)]     // непрямоугольный треугольник
    public void IsRightAngled_ReturnsCorrectResult(double sideA, double sideB, double sideC, bool expectedIsRightAngled)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        
        var actualIsRightAngled = triangle.IsRightAngled();
        
        Assert.Equal(expectedIsRightAngled, actualIsRightAngled);
    }
}