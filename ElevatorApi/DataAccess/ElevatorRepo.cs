using ElevatorApp.Entities;

namespace ElevatorApp.DataAccess;

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
