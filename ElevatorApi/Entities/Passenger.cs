using ElevatorApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorApp.Entities;

public class Passenger: IPassenger
{

    private Guid _id;
    
    public string Name { get; }
    public int Weight { get; }
    public State State { get; private set; }
    
    private PassengersActivity PassengersActivity { get; set; }

    public Passenger(int weight, string name)
    {
        _id = Guid.NewGuid();
        Weight = weight;
        State = State.Healthy;
        Name = name;
    }

    public void GetInjury()
    {
        Console.WriteLine($"{Name} survived the elevator crash and is waiting for the ambulance.");
        State = State.Injured;
    }

    public void Unalive()
    {
        Console.WriteLine($"Rest in peace, {Name}.");
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

    
    public void ChangeActivity(PassengersActivity passengersActivity)
    {
        PassengersActivity = passengersActivity;
        React(passengersActivity);
    }

    public void Act()
    {
        while (true)
        {
            
        }
    }
    
    
    
    private void React(PassengersActivity passengersActivity)
    {
        switch (passengersActivity)
        {
            case PassengersActivity.LyingInJanitorsTransporter:
                Console.WriteLine($"{Name} was loaded in the Janitor's transporter.");
                break;
            case PassengersActivity.WalkingInTheStreet:
                Console.WriteLine($"{Name} entered the street.");
                break;
            case PassengersActivity.LyingInAmbulance:
                Console.WriteLine($"{Name} was transported to the ambulance.");
                break;
            case PassengersActivity.WaitingForAmbulance:
                Console.WriteLine($"{Name} is injured and waiting for the ambulance.");
                break;
            case PassengersActivity.WaitingInLobby:
                Console.WriteLine($"{Name} is waiting in the lobby.");
                break;
            default:
                break;
        }
    }
}

public enum State
{
    Healthy = 0,
    Injured = 1,
    Dead = 2
}


public enum PassengersActivity
{
    WaitingInLobby = 0,
    WalkingInTheStreet = 1,
    LyingInAmbulance = 2,
    WaitingForAmbulance = 3,
    LyingInJanitorsTransporter = 4
}
