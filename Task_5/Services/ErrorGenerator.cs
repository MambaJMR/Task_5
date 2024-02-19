using Bogus.DataSets;
using Bogus;
using System;
using System.Globalization;
using Task_5.Interfaces;
using Task_5.Models;
using System.Reflection;
using Bogus.Bson;

namespace Task_5.Services
{
    public class ErrorGenerator : IErrorGenerator
    {
        private readonly Random random;
        private readonly int errorCount;
        private readonly Faker randomCharOrNum;
        private int errorVariants = 3;
        private int propertiesUser = 3;
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

        private string ErrorGenerate(string user)
        {
            //object[] met = { RemoveChar(user), InsertChar(user), ReplaceChar(user) };
            
            //for (int i = 0; i < errorCount; i++)
           // {
                int value = random.Next(errorVariants);

                //user = met[value].ToString();
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
           // }
            return user;
        }

        public List<TestUser> UserRandomString(List<TestUser> users)
        {
            

            foreach (var user in users)
            {
                for (int i = 0; i < errorCount; i++)
                {
                    int rnd = random.Next(propertiesUser);
                    switch (rnd)
                    {
                        case 0:
                            user.FullName = ErrorGenerate(user.FullName);
                            break;
                        case 1:
                            user.Address = ErrorGenerate(user.Address);
                            break;
                        case 2:
                            user.Phone = ErrorGenerate(user.Phone);
                            break;
                    }
                }
            }
            return users;
        }
    }
}
