namespace ElevatorApp.Entities;

public class Janitor
{

    private JanitorsLocation Location { get; set; }
    private JanitorsActivity Activity { get; set; }
    
    public Janitor()
    {
        Location = JanitorsLocation.Home;
        Activity = JanitorsActivity.Sleep;
    }


    public void GoToLobby()
    {
        Location = JanitorsLocation.Lobby;
        Console.WriteLine("Janitor came to the Büro lobby.");
    }
    
    public void LeaveTheBuro()
    {
        Location = JanitorsLocation.Street;
        Console.WriteLine("Janitor left the Büro.");
    }
    
    public void ComeHome()
    {
        Location = JanitorsLocation.Home;
        Console.WriteLine("Janitor came home.");
    }

    public void TakeOutBodies(Elevator elevator)
    {
        foreach (var passenger in elevator.GetCurrentPassengers())
        {
            if (passenger.IsDead())
            {
                Activity = JanitorsActivity.CleanElevator;
                React(JanitorsActivity.CleanElevator);
                // elevator.BeLeftBy(new List<Passenger>{passenger});
                // passenger.ChangeActivity(PassengersActivity.LyingInJanitorsTransporter);
            }
        }
    }

    private void React(JanitorsActivity janitorsActivity)
    {
        switch (janitorsActivity)
        {
            case JanitorsActivity.CleanElevator:
                Console.WriteLine("Janitor loaded a body into a transporter.");
                break;
            case JanitorsActivity.Sleep:
                Console.WriteLine("Janitor is sleeping. His light is off.");
                break;
            case JanitorsActivity.Drink:
                Console.WriteLine(
                    "Janitor's light is on. Now and then he puts empty wine bottles outside of his home.");
                break;
            default:
                break;
        }
    }
}

enum JanitorsLocation
{
    Home = 0,
    Street = 1,
    Lobby = 2
}

public enum JanitorsActivity
{
    Sleep = 0,
    Drink = 1,
    CleanElevator = 2,
}
