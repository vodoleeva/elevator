namespace ElevatorApp.Entities;

public class AmbulanceWorker
{

    private AmbulanceLocation Location { get; set; }
    private AmbulanceActivity Activity { get; set; }
    
    public AmbulanceWorker()
    {
        Location = AmbulanceLocation.Away;
        Activity = AmbulanceActivity.Disappear;
    }


    public void GoToLobby()
    {
        Location = AmbulanceLocation.Lobby;
        Console.WriteLine("Ambulance came to the Büro lobby.");
    }
    
    public void LeaveTheBuro()
    {
        Location = AmbulanceLocation.Street;
        Console.WriteLine("Ambulance left the Büro.");
    }
    
    public void Disappear()
    {
        Location = AmbulanceLocation.Away;
        Console.WriteLine("Ambulance left.");
    }

    public void TakeOutInjured(Elevator elevator)
    {
        foreach (var passenger in elevator.GetCurrentPassengers())
        {
            if (passenger.IsInjured())
            {
                Activity = AmbulanceActivity.PickUpPassengers;
                elevator.BeLeftBy(new List<Passenger> { passenger });
                passenger.ChangeActivity(PassengersActivity.LyingInJanitorsTransporter);
            }
        }
    }
}

enum AmbulanceLocation
{
    Away = 0,
    Street = 1,
    Lobby = 2
}

public enum AmbulanceActivity
{
    Disappear = 0,
    PickUpPassengers = 2,
}
