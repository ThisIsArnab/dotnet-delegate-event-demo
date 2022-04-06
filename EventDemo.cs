namespace DotnetDelegateEvents.EventDemo;

public static class EventDemo
{
    public static void SearchFile(string directory, string searchPattern)
    {
        int filesFound = 0;
        FileSearcher fileSearcher = new();

        // In this case we cannot remove the event hander (lambda) since we have directly added it to the subscriber.
        // To be able to later unsubscribe from the event, hold the lambda in a variable of type EventHandler<FileFoundArgs>
        fileSearcher.FileFound += (sender, eventArgs) =>
        {
            filesFound++;
            Console.WriteLine($"Found {eventArgs.FoundFile}!");
            System.Console.WriteLine("Files found: " + filesFound);
        };

        fileSearcher.Search(directory, searchPattern);
    }
}