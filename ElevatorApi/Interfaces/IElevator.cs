using ElevatorApp.Entities;

namespace ElevatorApp.Interfaces;

public interface IElevator
{
    public void MoveToLevel(int levelNr);
    public void GetFixed();
    
    public List<Passenger> GetCurrentPassengers();
    public void BeEnteredBy(List<Passenger>passengers);
    public void BeLeftBy(List<Passenger>passengers);
}
