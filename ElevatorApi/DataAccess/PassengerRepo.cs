using ElevatorApp.Interfaces;
using ElevatorApp.Services.Passenger;

namespace ElevatorApp.DataAccess;

public class PassengerRepo: IPassengerRepo
{
    public IPassenger CreatePassenger(int weight, string name)
    {
        return new Entities.Passenger(weight, name);
    }
}
