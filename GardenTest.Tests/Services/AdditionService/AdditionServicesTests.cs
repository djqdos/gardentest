using FluentAssertions;
using Xunit.Sdk;

namespace GardenTest.Tests.Services.AdditionService;
using GardenTest.Services.AdditionService;

public class AdditionServicesTests
{
    [Theory]
    [InlineData(1, 3, 4)]
    [InlineData(-1, 1, 0)]
    [InlineData(100, 100, 200)]
    public async Task AddNumbers_ShouldReturnCalculatedTotal(int num1, int num2, int expected)
    {
        // ARRANGE
        var service = new AdditionService();
        
        // ACT
        var response = await service.AddNumbers(num1, num2);
        
        // ASSERT
        response.Should().Be(expected);
    }
    
    
}