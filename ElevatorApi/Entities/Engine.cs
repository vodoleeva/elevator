using ElevatorApp.DataAccess;
using ElevatorApp.Interfaces;
using ElevatorApp.Services;

namespace ElevatorApp.Entities;

public class Engine
{
    private readonly IPassengerService _passengerService;
    public Engine()
    {
        _passengerService = new PassengerService(new PassengerRepo());
    }
    

    public void Run()
    {
        while (true)
        {
            var randomPassenger = _passengerService.CreateRandomPassenger();
            Console.WriteLine($"Name: {randomPassenger.Name}, Weight: {randomPassenger.Weight}");
        }
    }
}
