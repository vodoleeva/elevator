using ElevatorApp.Interfaces;

namespace ElevatorApp.Services.Passenger;

public interface IPassengerRepo
{
    public IPassenger CreatePassenger(int weight, string name);
}
