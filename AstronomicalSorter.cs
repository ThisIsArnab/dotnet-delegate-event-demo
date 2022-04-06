namespace DotnetDelegateEvents.Sorting;

public static class AstronomicalSorter
{
    public delegate float Comparison<in T>(T left, T right);

    // public static void Sort<T>(IList<T> astronomicalBodies, Comparison<T> comparator)
    // {
    //     Sorter(astronomicalBodies, comparator);
    // }

    // public static void SortStars(IList<Star> stars, Comparison<Star> comparator)
    // {
    //     Sorter(stars, comparator);
    // }

    // public static  void SortBlackHoles(IList<BlackHole> blackHoles, Comparison<BlackHole> comparator) {
    //     Sorter(blackHoles, comparator);
    // }

    // public static void SortGalaxies(IList<Galaxy> galaxies, Comparison<Galaxy> comparator) {
    //     Sorter(galaxies, comparator);
    // }

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

// public static class ComparerHelper
// {
//     public static AstronomicalSorter.Comparison<T> GetComparer<T>(Func<T, IComparable> property)
//     {
//         return (astronomicalBodyA, astronomicalBodyB) => property(astronomicalBodyA).CompareTo(property(astronomicalBodyB));
//     }
// }

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
