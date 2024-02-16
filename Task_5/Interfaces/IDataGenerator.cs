using Task_5.Models;

namespace Task_5.Interfaces
{
    public interface IDataGenerator
    {
        List<TestUser> GeneratePerson(string region, int seed);
    }
}