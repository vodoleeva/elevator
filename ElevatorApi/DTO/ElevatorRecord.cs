namespace ElevatorApp.DTO;

public record ElevatorRecord
{
    // todo: what is init
    public int CurrentWeight { get; init; }
    public bool IsBroken { get; init; }
    public int CurrentLevel { get; init; }
    public bool IsActive { get; init; }
}
