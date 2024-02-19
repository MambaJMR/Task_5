using Task_5.Models;

namespace Task_5.Interfaces
{
    public interface IUserResponse
    {
        List<TestUser> GetUsers(int seed, string region, int errorValue);
    }
}