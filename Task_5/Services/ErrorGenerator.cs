using Bogus.DataSets;
using Bogus;
using System;
using System.Globalization;

namespace Task_5.Services
{
    public class ErrorGenerator
    {
        private readonly Random random;
        private readonly int errorCount;
        private readonly Faker randomCharOrNum;
        public ErrorGenerator(int seed, int errorCount, string region)
        {
            randomCharOrNum = new Faker(region);
            random = new Random(seed);
            this.errorCount = errorCount;
        }
        string RemoveChar(string user)
        {
            if (user.Length != 1)
            {
                var value = random.Next(user.Length - 1);
                return user.Remove(value, 1);
            }
            return user;
        }
        string InsertChar(string user)
        {
            Randomizer.Seed = random;
            var randomChar = randomCharOrNum.Lorem.Letter(1);
            var randomNum = randomCharOrNum.Random.Int(0, user.Length);
            return user.Insert(randomNum, randomChar);
        }
        string ReplaceChar(string user)
        {
            Randomizer.Seed = random;
            var randomChar = Convert.ToChar(randomCharOrNum.Random.Replace("*"));
            var randomNum = randomCharOrNum.Random.Int(0, user.Length - 1);
            return user.Replace(user[randomNum], randomChar); ;
        }

        public string ErrorGenerate(string user)
        {
            int errorVariants = 3;
            for (int i = 0; i < errorCount; i++)
            {
                int value = random.Next(errorVariants);
                switch (value)
                {
                    case 0:
                        user = RemoveChar(user);
                        break;
                    case 1:
                        user = InsertChar(user);
                        break;
                    case 2:
                        user = ReplaceChar(user);
                        break;
                }
            }
            return user;
        }
    }
}
