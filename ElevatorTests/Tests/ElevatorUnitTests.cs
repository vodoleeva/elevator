using ElevatorApp.Entities;

namespace ElevatorTests.Tests;

public class ElevatorUnitTests
{
    [Fact]
    public void ElevatorGetsOverloaded()
    {
        var elevator1 = new Elevator(150);

        Passenger passenger1 = new Passenger( 100);
        Passenger passenger2 = new Passenger(80);
        
        elevator1.AddPassenger(passenger1);
        elevator1.AddPassenger(passenger2);
    
        var isFull1 = elevator1.IsMaxWeightAchieved();

        elevator1.RemovePassenger(passenger1);
        var isFull2 = elevator1.IsMaxWeightAchieved();
        
        Assert.True(isFull1);
        Assert.False(isFull2);
    }
}
