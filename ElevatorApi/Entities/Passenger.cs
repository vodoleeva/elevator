namespace ElevatorApp.Entities;

public class Passenger
{
    private Guid _id;
    
    private readonly int _weight;

    public Passenger(int weight)
    {
        _id = Guid.NewGuid();
        _weight = weight;
    }

    public int GetWeight()
    {
        return _weight;
    }


}
