using GeometryLibrary.Interfaces;

namespace GeometryLibrary;

public static class ShapeCalcUtility
{
    public static double CalculateArea(IShape shape) => shape.CalculateArea();
}