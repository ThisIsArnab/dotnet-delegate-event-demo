namespace DotnetDelegateEvents.Sorting;

public static class AstronomicalSorter
{
    public delegate float Comparison<in T>(T left, T right);

    public static Comparison<T> GetComparer<T>(Func<T, IComparable> property)
    {
        return (astronomicalBodyA, astronomicalBodyB) => property(astronomicalBodyA).CompareTo(property(astronomicalBodyB));
    }

    public static void Sort<T>(IList<T> items, Comparison<T> comparator)
    {
        // Implement some fancy sorting algorithm
        var arrayItems = items.ToArray();
        for (int i = 0; i < arrayItems.Length - 1; i++)
        {
            for (int j = 0; j < arrayItems.Length - i - 1; j++)
            {
                if(comparator(arrayItems[j], arrayItems[j+1]) > 0)
                {
                    (arrayItems[j+1], arrayItems[j]) = (arrayItems[j], arrayItems[j+1]);
                }
            }
        }

        for (int i = 0; i < arrayItems.Length; i++)
        {
            items[i] = arrayItems[i];
        }
    }
}

public class Star
{
    public float LightYearDistanceFromEarth { get; set; }

    public float DiameterTimesSun { get; set; }

    public float MassTimesSun { get; set; }

    public float Luminosity { get; set; }
}

public class BlackHole
{
    public float LightYearDistanceFromEarth { get; set; }

    public float MassTimesSun { get; set; }

    public float HawkingRadiation { get; set; }
}

public class Galaxy
{
    public float LightYearDistanceFromEarth { get; set; }

    public string? HubbleClassification { get; set; }

    public float RadialVelocity { get; set; }

    public float Luminosity { get; set; }
}
