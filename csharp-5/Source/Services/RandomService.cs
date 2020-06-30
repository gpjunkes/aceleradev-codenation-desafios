using System;

namespace Codenation.Challenge.Services
{
    public class RandomService: IRandomService
    {
        public int RandomInteger(int max)
        {
            Random randNum = new Random();
            return randNum.Next(0, max);
        }
    }
}