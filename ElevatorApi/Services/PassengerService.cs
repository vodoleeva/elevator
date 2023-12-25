using ElevatorApp.Interfaces;
using ElevatorApp.Services.Passenger;

namespace ElevatorApp.Services;

public class PassengerService: IPassengerService
{
    private readonly IPassengerRepo _passengerRepo;
    
    public PassengerService(IPassengerRepo repo)
    {
        _passengerRepo = repo;
    }
    
    private static readonly List<string> PassengerNames = new List<string> {"Joe", "Janine", "Martha", "Chandler"};

    private static readonly Dictionary<WeightCategory, int> WeightDic = new Dictionary<WeightCategory, int>()
    {
        {WeightCategory.Boy, 30},
        {WeightCategory.Girl, 40},
        {WeightCategory.Man, 100},
        {WeightCategory.Woman, 60},
        {WeightCategory.BigMan, 130},
        {WeightCategory.BigWoman, 100}
    };
        

    public IPassenger CreateRandomPassenger()
    {
        var random = new Random();
        int nameIdx = random.Next(PassengerNames.Count);

        var values = Enum.GetValues(typeof(WeightCategory));
        WeightCategory randomWeightCategory = (WeightCategory) values.GetValue(random.Next(values.Length));
        
        return _passengerRepo.CreatePassenger(WeightDic[randomWeightCategory], PassengerNames[nameIdx]);
        
    }
}

public enum WeightCategory
{
    Boy,
    Girl,
    Man, 
    Woman,
    BigMan, 
    BigWoman
}
