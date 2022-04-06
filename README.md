# Delegate concepts and notes:
* Define delegate type with `delegate` keyword. E.g.  
  ```C#
  public delegate int Comparison<in T>(T left, T right)
  ```  
  
* Declare instances of the delegate type:  
  ```C#
  public Comparison<T> comparator;
  ```
  
* Invoke delegates:
  ```c#
  int result = comparator(left, right);
  ```
  
  ### Note:
  - `in`/`out` keywords on generic type is used for covariance :
    ``` C#
    ppublic delegate TResult Func<in T1, out TResult>(T1 arg)
    ```
  - Delegates are by default multicast  

  - **Q. What would you have done to implement LINQ if delegates were not a language feature**  
    -> Need to create class that derives from particular base class or implement a aspecific interface 
    
  - **Q. How to handle null delegates?**  
    ```C#
    public static void LogMessage(string msg)
    {
      WriteMessage?.Invoke(msg);
      // instead of
      // WriteMessage(msg)
      ...
    }
    ```
  - **Q. What advantage does delegates bring to the table?**  
    -> Loose coupling can be maintained between implementation and structure. For e.g. we can have loosely coupled logger and log mechanisms.
       Can add more log mechanisms later without modifying logger.

# Events concepts and Notes
Event Source (Producer) <--> Event Sink (Consumer)

* ### Design Goals for Events:
  * Very minimum coupling between event source(producers) and event sink(consumers)
  * Should be easy to subscribe to an event and unsubscribe from an event.
  * Event sources should suport multiple event subscriptions. It should also support zero subscribers.

* ### Event Subscription and unscription:
  * Subscribe to an event by : `+=`
  * Unsubscribe from an event by : `-=`  
    Remember: you need to assign the lambda handler function to a variable to be able to later unsubscribe from an evnet.
  
* ### Standard signature for a .NET event delegate:
  ```C#
  void OnEventRaised(Object sender, EventArgs args)
  ```
  **Note**: Events have void return type. Data should pass through args.
  
* ### Publish Events and add Subscribers:
  1. Declare events:
     ```C#
     public event EventHandler<FileFoundArgs> FileFound;
     ```
  2. Define a class or a struct (only with dotnet core):
     ```C#
     public class FileFoundArgs: EventArgs
     {
        public string FoundFile { get; }

        public bool CancelRequested { get; set; }

        public FileFoundArgs(string fileName)
        {
          FoundFile = fileName;
        }
     }
     ```
  3. Publish events to subscribers:
     ```C#
     FileFound?.Invoke(this, new FileFoundArgs(file));
     ```
  4. Subscribers are like:
     ```C#
     FileSearcher fileSearcher = new();
     fileSearcher.FileFound += (sender, eventArgs) =>
        {
            filesFound++;
            Console.WriteLine($"Found {eventArgs.FoundFile}!");
            Console.WriteLine("Files found: " + filesFound);
        };
     ```

# When to use Delegate vs Events
  * When callback pattern required - use delegates.
    e.g. `List.Sort()` must be supplied with a comparer function. This is a candidate to implement delegate.  
  * When calling subscribers optional - use events.
  e.g. Consider 'progress' oeration. Task continues to roceed whether or not there are any listeners. This is a perfect candidate for event pattern.
  * Delegates can have return values but events don't. Event return type is void. So, async events needs to be declared void async.
  * Event invocation can only be done in the class where the event was declared not any other class.

