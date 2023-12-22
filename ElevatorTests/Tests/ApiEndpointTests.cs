using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.TestHost;

namespace ElevatorTests.Tests;

public class ApiEndpointTests
{
    private readonly HttpClient _client;

    public ApiEndpointTests()
    {
        var webBuilder = new WebHostBuilder();
        webBuilder.UseStartup<TestStartup>();
        var testServer = new TestServer(webBuilder);
        _client = testServer.CreateClient();
    }

    [Fact]
    public async Task GetElevator_ReturnsCorrectResponse()
    {
        // Arrange
        var url = $"api/blabla";
        
        // Act
        var result = await _client.GetAsync(url);

        // Assert
        Assert.Equal(StatusCodes.Status404NotFound, (int)result.StatusCode);
    }
}
