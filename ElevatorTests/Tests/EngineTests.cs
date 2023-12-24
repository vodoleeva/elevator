using ElevatorApp.Entities;

namespace ElevatorTests.Tests;

public class EngineTests
{
    [Fact]
    public void EngineIsASingleton()
    {

        string value1 = "", value2 = "";
        
        Thread process1 = new Thread(() =>
        {
            var singleton1 = Engine.GetInstance("FOO");
            value1 = singleton1.Value;
        });
        Thread process2 = new Thread(() =>
        {
            var singleton2 = Engine.GetInstance("BAR");
            value2 = singleton2.Value;
        });
            
        process1.Start();
        process2.Start();
            
        process1.Join();
        process2.Join();
        
        Assert.Same(value1, value2);
        
    }
}
