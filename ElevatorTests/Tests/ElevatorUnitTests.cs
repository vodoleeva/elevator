using ElevatorApp.Entities;

namespace ElevatorTests.Tests;

public class ElevatorUnitTests
{
    [Fact]
    public void ElevatorGetsOverloaded()
    {
        var elevator = new Elevator(150);

        Passenger passenger1 = new Passenger( 100);
        Passenger passenger2 = new Passenger(80);
        
        elevator.AddPassengers(new List<Passenger>{passenger1, passenger2});

        var isFull1 = elevator.IsMaxWeightAchieved();

        elevator.RemovePassengers(passenger1);
        var isFull2 = elevator.IsMaxWeightAchieved();
        
        Assert.True(isFull1);
        Assert.False(isFull2);
    }

    [Fact]
    public void ElevatorSometimesCrashes()
    {
        var elevator = new Elevator(300);
        Passenger passenger1 = new Passenger( 100);
        Passenger passenger2 = new Passenger(80);
        
        elevator.AddPassengers(new List<Passenger>{passenger1, passenger2});
        
        // move up and down till it breaks
        while (!elevator.IsBroken())
        {
            while (elevator.Level != Elevator.Levels[^1])
            {
                elevator.MoveUp();
                if (elevator.IsBroken())
                {
                    break; // duh.
                }
            }
            
            while (elevator.Level != Elevator.Levels[0])
            {
                elevator.MoveDown();
                if (elevator.IsBroken())
                {
                    break; 
                }
            }
        }
        
        Assert.True(elevator.IsBroken());
        
        
    }
}
