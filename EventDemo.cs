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
            Console.WriteLine("Files found: " + filesFound);
        };

        fileSearcher.Search(directory, searchPattern);
    }

    /// <summary>
    /// Overloaded method to stop searching after certain number of files are found
    /// </summary>
    public static void SearchFile(string directory, string searchPattern, int searchCount)
    {
        if (searchCount == 0)
        {
            return;
        }

        int filesFound = 0;
        FileSearcher fileSearcher = new();

        fileSearcher.FileFound += (sender, eventArgs) =>
        {
            filesFound++;
            Console.WriteLine($"Found {eventArgs.FoundFile}!");
            Console.WriteLine("Files found: " + filesFound);

            if(filesFound == searchCount)
            {
                eventArgs.CancelRequested = true;
            }
        };

        fileSearcher.List(directory, searchPattern);
    }
}