namespace ElevatorApp.Entities;

public class Elevator
{
    private readonly int _maxWeight;
    private int _currentWeight;
    private readonly Guid _id;
    private bool _isActive;
    
    public static int amountOfActiveEvevators;
    
    
    // position
    // randomly broken
    // call technician
    // repair within 30 seconds



    public Elevator(int maximalWeight)
    {
        _maxWeight = maximalWeight;
        _currentWeight = 0;
        _id = Guid.NewGuid();
    }

    public void AddPassenger(Passenger passenger)
    {
        if (_currentWeight <= 0)
        {
            amountOfActiveEvevators += 1;
        }

        _isActive = true;
        _currentWeight += passenger.GetWeight();
        Console.WriteLine($"Plus {passenger.GetWeight()} kg. Current weight {_currentWeight} kg.");
    }
    
    public void RemovePassenger(Passenger passenger)
    {
        _currentWeight -= passenger.GetWeight();
        if (_currentWeight <= 0)
        {
            amountOfActiveEvevators -= 1;
            _isActive = false;
        }
        Console.WriteLine($"Minus {passenger.GetWeight()} kg. Current weight {_currentWeight} kg.");
    }
    
    

    public bool IsMaxWeightAchieved()
    {
        bool isElevatorFull = _currentWeight >= _maxWeight;
        if (isElevatorFull)
        {
            Console.WriteLine($"Elevator {_id} is full.");
        }

        return isElevatorFull;
    }
    
}
