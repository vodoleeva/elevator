
using ElevatorApp.Interfaces;

namespace ElevatorApp.Entities;


public class Elevator: IElevator
{
    private readonly int _maxWeight;
    private readonly Guid _id;
    private int _currentWeight;
    private int Level { get; set; }
    private bool IsBroken { get; set; }
    private bool IsOpen { get; set; }
    private List<Passenger> Passengers { get; set; }

    private static readonly int[] Levels = { 1,2,3,4,5,6,7,8 };
    
    public static int amountOfActiveEvevators;
    
    public Elevator(int maximalWeight)
    {
        Level = 1;
        _maxWeight = maximalWeight;
        _currentWeight = 0;
        _id = Guid.NewGuid();
        Passengers = new List<Passenger>();
        IsBroken = false;
        IsOpen = false;
    }

    public List<Passenger> GetCurrentPassengers()
    {
        return Passengers;
    }

    public void BeEnteredBy(List<Passenger> passengers)
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
    
    public void BeLeftBy(List<Passenger> passengers)
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
    

    public bool IsMaxWeightAchieved()
    {
        bool isElevatorFull = _currentWeight >= _maxWeight;
        if (isElevatorFull)
        {
            Console.WriteLine($"Elevator {_id} is too full.");
        }

        return isElevatorFull;
    }

    // The elevator crashes now and then and falls to the first floor. There might be casualties involved.
    private void RandomlyBreak()
    { 
        // break approx. in 10% of trips
        var rnd = new Random();
        int result = rnd.Next(1, 10);
        if (result == 1)
        {
            IsBroken = true;
            Level = Levels[0];
            RandomlyInjurePassengers();
        }
    }

    // Some passengers are lucky to survive the elevator crash.
    public void MoveToLevel(int levelNr)
    {

        if (Level != levelNr)
        {
            Close();
            if (levelNr > Level)
            {
                while (Level <= Levels[^1])
                {
                    Level += 1;
                    RandomlyBreak();
                }
            }
            else
            {
                while (Level >= Levels[0])
                {
                    Level -= 1;
                    RandomlyBreak();
                }
            }
            Open();
        }
    }

    private void Open()
    {
        IsOpen = true;
    }

    private void Close()
    {
        IsOpen = false;
    }

    public void GetFixed()
    {
        IsBroken = false;
    }

    private List<Passenger> RandomlyInjurePassengers()
    {
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

        return Passengers;
    }
}
