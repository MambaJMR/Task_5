using Bogus;
using Task_5.Interfaces;
using Task_5.Models;

namespace Task_5.Services
{
    public class DataGenerator : IDataGenerator
    {
        private int NumberOfEntries = 20;
        public List<TestUser> GeneratePersons(string region, int seed)
        {
            
            Randomizer.Seed = new Random(seed);
            var _personModelFake = new Faker<TestUser>(region)
                .RuleFor(u => u.FullName, f => f.Name.FindName()) 
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber());

            return _personModelFake.Generate(NumberOfEntries);
        }
    }
}
