namespace ElevatorApp.Entities;

public class Passenger
{
    private Guid _id;
    public int Weight { get; private set; }
    public State State { get; private set; }

    public Passenger(int weight)
    {
        _id = Guid.NewGuid();
        Weight = weight;
        State = State.Healthy;
    }

    public void GetInjury()
    {
        State = State.Injured;
    }

    public void Unalive()
    {
        State = State.Dead;
    }
    
    public bool IsInjured()
    {
        return State == State.Injured;
    }
    
    public bool IsDead()
    {
        return State == State.Dead;
    }
}

public enum State
{
    Healthy = 0,
    Injured = 1,
    Dead = 2
}
