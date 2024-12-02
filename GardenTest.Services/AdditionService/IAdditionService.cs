namespace GardenTest.Services.AdditionService;

public interface IAdditionService
{
    Task<int> AddNumbers(int number1, int number2);
}