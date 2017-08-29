using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallengeRunner.Challenges.Shared;

namespace CodeChallengeRunner.Challenges.Bowling
{
    // From: http://codingdojo.org/kata/Bowling/
    public class BowlingChallengeRunner
    {
        private RandomProvider random;

        public BowlingChallengeRunner(RandomProvider random)
        {
            this.random = random;
        }

        private Dictionary<int,BowlingChallenge> challenges = new Dictionary<int,BowlingChallenge>
        {
            { 1, new BowlingChallenge() { Id = 1, Frames = "X X X X X X X X X X X X", Score = 300 } },
            { 2, new BowlingChallenge() { Id = 2, Frames = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", Score = 90 } },
            { 3, new BowlingChallenge() { Id = 3, Frames = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", Score = 150 } },
            { 4, new BowlingChallenge() { Id = 4, Frames = "- - - - - - - - - -", Score = 0 } },
        };

        public BowlingChallenge GetRandomChallenge()
        {
            var randomId = random.GetRandom(1, challenges.Keys.Count);
            return challenges[randomId];
        }

        public bool TestChallenge(int id, int testScore)
        {
            return testScore == challenges[id].Score;
        }
    }
}
