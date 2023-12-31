namespace ElevatorApp.Helper;

public class DateHelper
{
    public static T ExecuteWithTimeout<T>(Func<T> function, TimeSpan timeout, Func<T> onTimeout)
    {
        Task<T> task = Task.Run(function);
        if (task.Wait(timeout))
        {
            // the function returned in time
            return task.Result;
        }
        else
        {
            return onTimeout();
        }
    }
}
