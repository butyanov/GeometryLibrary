namespace GeometryLibrary1.Abstractions;

public abstract class Shape
{
    public abstract double CalculateArea();

    protected virtual void ValidateMeasures()
    {
        return;
    }
}