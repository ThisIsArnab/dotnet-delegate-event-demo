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
