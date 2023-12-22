using ElevatorApp.Entities;

namespace ElevatorApp.Repo;

public class ElevatorRepo
{
    public IEnumerable<Elevator> GetElevators()
    {
        return new[]
        {
            new Elevator(300),
            new Elevator(300)
        };
    }
}
