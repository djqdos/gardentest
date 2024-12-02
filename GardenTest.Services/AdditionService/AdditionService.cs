namespace GardenTest.Services.AdditionService;

public class AdditionService : IAdditionService
{
    public async Task<int> AddNumbers(int number1, int number2)
    {
        return await Task.FromResult(number1 + number2);
    }
}