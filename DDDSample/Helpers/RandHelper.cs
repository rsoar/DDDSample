namespace DDDSample.Helpers;

public static class RandHelper
{
    public static int GenerateNumber(int min, int max)
    {
        Random rand = new();
        return rand.Next(min, max);
    }
}