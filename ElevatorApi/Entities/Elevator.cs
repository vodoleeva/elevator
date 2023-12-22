
namespace ElevatorApp.Entities;


public class Elevator
{
    private readonly int _maxWeight;
    private int _currentWeight;
    private readonly Guid _id;
    public int Level { get; private set; }
    public ElevatorState State { get; private set; }
    public List<Passenger> Passengers { get; private set; }

    public static readonly int[] Levels = { 1,2,3,4,5,6,7,8 };
    public static int amountOfActiveEvevators;

    
    // call technician
    // repair within 30 seconds

    
    public Elevator(int maximalWeight)
    {
        Level = 1;
        _maxWeight = maximalWeight;
        _currentWeight = 0;
        _id = Guid.NewGuid();
        Passengers = new List<Passenger>();
        State = ElevatorState.Ok;
    }

    public void AddPassengers(List<Passenger> passengers)
    {
        if (_currentWeight <= 0)
        {
            amountOfActiveEvevators += 1;
        }

        var passengersWeight = passengers.Sum(i => i.Weight);
        _currentWeight += passengersWeight;
        
        Passengers.AddRange(passengers);
        
        Console.WriteLine($"Plus {passengersWeight} kg. Current weight {_currentWeight} kg.");
    }
    
    public void RemovePassengers(List<Passenger> passengers)
    {
        
        foreach (var passenger in passengers)
        {
            Passengers.Remove(passenger);
        }
        
        var passengersWeight = passengers.Sum(i => i.Weight);
        _currentWeight -= passengersWeight;

        if (_currentWeight <= 0)
        {
            amountOfActiveEvevators -= 1;
        }
        Console.WriteLine($"Minus {passengersWeight} kg. Current weight {_currentWeight} kg.");
    }
    
    public void RemovePassengers(Passenger passenger)
    {
        
        Passengers.Remove(passenger);
        
        _currentWeight -= passenger.Weight;

        if (_currentWeight <= 0)
        {
            amountOfActiveEvevators -= 1;
        }
        Console.WriteLine($"Minus {passenger.Weight} kg. Current weight {_currentWeight} kg.");
    }


    public void MoveUp()
    {
        if (Level <= Levels[^1])
        {
            Level += 1;
            RandomlyBreak();
        }
    }
    
    public void MoveDown()
    {
        if (Level >= Levels[0])
        {
            Level -= 1;
            RandomlyBreak();
        }
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

    // The elevator crashes now and then, falls to the first floor. There might be casualties involved.
    private void RandomlyBreak()
    { 
        // break approx. in 10% of trips
        var rnd = new Random();
        int result = rnd.Next(1, 10);
        if (result == 1)
        {
            State = ElevatorState.Broken;
            Level = Levels[0];
            RandomlyInjurePassengers();
        }
    }

    // Some passengers are lucky to survive the elevator crash.
    private void RandomlyInjurePassengers()
    {
        if (Passengers.Count == 0)
        {
            return;
        }
        var rnd = new Random();
        foreach (var passenger in Passengers)
        {
            if (rnd.Next(1, 10) < 4)
            {
                passenger.Unalive();
            } else if (rnd.Next(1, 10) > 7)
            {
                passenger.GetInjury();
            }
        }
    }

    public enum ElevatorState
    {
        Ok = 0,
        Broken = 1
    }

    public bool IsBroken()
    {
        return State == ElevatorState.Broken;
    }
    

}
