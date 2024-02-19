using Task_5.Interfaces;
using Task_5.Models;

namespace Task_5.Services
{
    public class UserResponse : IUserResponse
    {
        IDataGenerator _generator;
        IErrorGenerator _errorGenerator;
        public UserResponse(IDataGenerator dataGenerator)
        {
            _generator = dataGenerator;
        }
        public List<TestUser> GetUsers(int seed, string region, int errorValue)
        {
            _errorGenerator = new ErrorGenerator(seed, errorValue, region);
            var user = _generator.GeneratePersons(region, seed);
            return _errorGenerator.UserRandomString(user);
        }
    }
}
