using ElevatorApp.Entities;

namespace ElevatorTests.Tests;

public class ElevatorUnitTests
{
    [Fact]
    public void ElevatorGetsOverloaded()
    {
        var elevator = new Elevator(150);

        Passenger passenger1 = new Passenger( 100, "Jane");
        Passenger passenger2 = new Passenger(80, "Ron");
        
        elevator.AddPassengers(new List<Passenger>{passenger1, passenger2});

        var isFull1 = elevator.IsMaxWeightAchieved();

        elevator.RemovePassengers(passenger1);
        var isFull2 = elevator.IsMaxWeightAchieved();
        
        Assert.True(isFull1);
        Assert.False(isFull2);
    }

    [Fact]
    public void ElevatorSometimesInjuresPassengers()
    {
        var elevator = new Elevator(300);
        Passenger passenger1 = new Passenger( 100, "Jane");
        Passenger passenger2 = new Passenger(80, "Ron");
        
        elevator.AddPassengers(new List<Passenger>{passenger1, passenger2});
        
        // move up and down till it breaks
        MoveElevatorTillItBreaks(elevator);
        
        Assert.True(IsAnyoneInjured(elevator.Passengers));
    }

    private void MoveElevatorTillItBreaks(Elevator elevator)
    {
        while (!IsAnyoneInjured(elevator.Passengers))
        {
            while (elevator.Level != Elevator.Levels[^1])
            {
                elevator.MoveUp();
                if (IsAnyoneInjured(elevator.Passengers))
                {
                    break;
                }
            }
            
            while (elevator.Level != Elevator.Levels[0])
            {
                elevator.MoveDown();
                if (IsAnyoneInjured(elevator.Passengers))
                {
                    break;
                }
            }

            MoveElevatorTillItBreaks(elevator);
        }
    }

    private bool IsAnyoneInjured(List<Passenger>passengers)
    {
        return passengers.FindIndex(p => p.IsInjured() || p.IsDead()) != -1;
    }
}
