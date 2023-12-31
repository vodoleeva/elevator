using System.ComponentModel.DataAnnotations;

namespace ElevatorApp.Helper;

public class ProbabilityHelper
{
    public static void ExecuteWithProbability<T>(Func<T> func, decimal probability)
    {
        if (probability is < 0 or > 1)
        {
            throw new ValidationException("Probability should be between 0 and 1.");
        }

        var rnd = new Random();
        var probabilityAsInt = probability * 10;
        if (rnd.Next(1, 10) < probabilityAsInt)
        {
            func();
        }
    }
}
