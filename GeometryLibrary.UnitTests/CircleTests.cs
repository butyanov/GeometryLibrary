using GeometryLibrary.Interfaces;
using GeometryLibrary.Shapes;

namespace GeometryLibrary.UnitTests;

public class CircleTests
{
    [Theory]
    [InlineData(2, 12.566370614359172)]
    [InlineData(0, 0)]
    [InlineData(5.5, 95.033177771091246)]
    public void CalculateArea_ReturnsCorrectArea(double radius, double expectedArea)
    {
        // Arrange
        IShape circle = new Circle(radius);

        // Act
        var actualArea = ShapeCalcUtility.CalculateArea(circle);

        // Assert
        Assert.Equal(expectedArea, actualArea, 10);
    }
}