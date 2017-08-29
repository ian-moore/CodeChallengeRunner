using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeRunner.Challenges.Shared
{

    public class RandomProvider
    {
        private Random random;

        public RandomProvider()
        {
            random = new Random();
        }

        public int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
