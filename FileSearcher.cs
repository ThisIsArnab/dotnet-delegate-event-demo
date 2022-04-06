namespace DotnetDelegateEvents.EventDemo;

/// <summary>
/// This is a demostration of events in .net.
/// Events are basically delegates with certain constrains and patterns
/// </summary>
public class FileSearcher
{
    public event EventHandler<FileFoundArgs> FileFound;

    public void Search(string directory, string searchPattern)
    {
        foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
        {
            FileFound?.Invoke(this, new FileFoundArgs(file));
        }
    }
}

/// <summary>
/// This class will be used as the argument to the event fired.
/// This can be a constructor instead if using .net core (new pattern)
/// On a side note, args proerties should be immutable (for most scenarios)
/// </summary>
public class FileFoundArgs: EventArgs
{
    public string FoundFile { get; }

    public FileFoundArgs(string fileName)
    {
        FoundFile = fileName;
    }

}