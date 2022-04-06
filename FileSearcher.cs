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

    /// <summary>
    /// As you will see, the Invoke() method calls the lambda and the execution context moves to the lambda and
    /// then retuns back to this List() method
    /// </summary>
    public void List(string directory, string searchPattern)
    {
        foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
        {
            var args = new FileFoundArgs(file);
            FileFound?.Invoke(this, args);

            if(args.CancelRequested)
            {
                break;
            }
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

    public bool CancelRequested { get; set; }

    public FileFoundArgs(string fileName)
    {
        FoundFile = fileName;
    }

}