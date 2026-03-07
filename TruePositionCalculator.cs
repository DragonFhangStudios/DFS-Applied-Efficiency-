using System;

namespace AerospaceCalc;

public class TruePositionCalculator
{
    public decimal CalculateTruePosition(decimal xActual, decimal xTarget, decimal yActual, decimal yTarget)
    {
        // TP = 2 * SQRT( (X_act - X_tar)^2 + (Y_act - Y_tar)^2 )
        decimal xDiff = xActual - xTarget;
        decimal yDiff = yActual - yTarget;

        // Allowed cast to double specifically for Math.Sqrt due to precision limits of the method.
        decimal xDiffSquared = xDiff * xDiff;
        decimal yDiffSquared = yDiff * yDiff;

        decimal sqrtResult = (decimal)Math.Sqrt((double)(xDiffSquared + yDiffSquared));

        return 2.0m * sqrtResult;
    }
}
