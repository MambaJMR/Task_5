using Task_5.Models;

namespace Task_5.Interfaces
{
    public interface IErrorGenerator
    {
        List<TestUser> UserRandomString(List<TestUser> users);
    }
}