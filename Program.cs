// See https://aka.ms/new-console-template for more information
using DotnetDelegateEvents.EventDemo;
using DotnetDelegateEvents.Sorting;

Console.WriteLine("Hello, World!");
if (args.Length == 0)
{
    Console.WriteLine("No command line argument provided!");
}

string myString = "This is a line of text";
Console.WriteLine("Before param passing: " + myString);

var paramPassing = new ParameterPassing();
paramPassing.FormatText(ref myString);

Console.WriteLine("After param passing: " + myString);

var stars = new List<Star>(new Star[] {
    new Star{ DiameterTimesSun = 1.1F,  LightYearDistanceFromEarth = 2.5F,      Luminosity=3.2F,        MassTimesSun = 5.8F },
    new Star{ DiameterTimesSun = 2.1F,  LightYearDistanceFromEarth = 15.5F,     Luminosity=12F,         MassTimesSun = 123F },
    new Star{ DiameterTimesSun = 3.2F,  LightYearDistanceFromEarth = 25F,       Luminosity=15F,         MassTimesSun = 500F },
    new Star{ DiameterTimesSun = 0.88F, LightYearDistanceFromEarth = 75F,       Luminosity=4.5F,        MassTimesSun = 0.9F },
    new Star{ DiameterTimesSun = 1.3F,  LightYearDistanceFromEarth = 12.2F,     Luminosity=7.2F,        MassTimesSun = 0.88F },
});
// AstronomicalSorter.SortStars(stars, AstronomicalSorter.GetComparer<Star>(x => x.DiameterTimesSun));
AstronomicalSorter.Sort(stars, AstronomicalSorter.GetComparer<Star>(x => x.DiameterTimesSun));
Console.WriteLine(string.Join(", ", stars.Select(star => star.DiameterTimesSun)));


// Search a file in a directory
EventDemo.SearchFile(@"D:\dev_temp\dotnetDelegateEvents", "AstronomicalSorter.cs");