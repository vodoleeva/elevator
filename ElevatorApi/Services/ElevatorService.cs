using ElevatorApp.DTO;
using ElevatorApp.Entities;
using ElevatorApp.Repo;

namespace ElevatorApp.Services;

public class ElevatorService
{
    private readonly ElevatorRepo _repo;
    
    public ElevatorService(ElevatorRepo repo)
    {
        _repo = repo;
    }

    public IEnumerable<Elevator> GetCurrentElevators()
    {
        var elevators = _repo.GetElevators();
        return elevators;
    }

}
