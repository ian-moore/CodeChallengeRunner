using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeChallengeRunner.Challenges.Bowling
{
    public class BowlingChallenge
    {
        public BowlingChallenge()
        {

        }

        public int Id { get; set; }

        public int Score { get; set; }

        public string Frames { get; set; }
    }

    public class BowlingChallengeInput
    {
        public int Id { get; set; }
        public int Score { get; set; }
    }

    public class BowlingChallengeOutput
    {
        public int Id { get; set; }
        public string Frames { get; set; }
    }
}
