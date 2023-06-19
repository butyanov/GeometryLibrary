using GeometryLibrary.Types;

namespace GeometryLibrary.UnitTests;

public class MeasureTests
{
    [Theory]
    [InlineData(5.0)]
    [InlineData(10.0)]
    [InlineData(15.5)]
    public void ValidateValue_ValidValue_DoesNotThrowException(double value)
    {
        var measure = new Measure(value);
        
        Assert.Equal(measure.Value, value);
    }

    [Theory]
    [InlineData(double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity)]
    public void ValidateValue_InfiniteValue_ThrowsArgumentOutOfRangeException(double value)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Measure(value));
    }

    [Fact]
    public void ValidateValue_NaNValue_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Measure(double.NaN));
    }

    [Theory]
    [InlineData(0.0)]
    [InlineData(-42.0)]
    public void ValidateValue_NonPositiveValue_ThrowsArgumentOutOfRangeException(double value)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Measure(value));
    }
}
