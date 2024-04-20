namespace ArgData.Validation;

internal static class DriverNumberValidator
{
    internal static void Validate(int driverNumber)
    {
        if (driverNumber < 0 || driverNumber > 40)
            throw new ArgumentOutOfRangeException(nameof(driverNumber),
                "Driver numbers must be between 0 (inactive) and 40.");
    }
}