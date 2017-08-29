using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeRunner.Challenges.BankOCR
{
    public class BankOCRChallenge
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string[] PrintedNumbers { get; set; }
    }

    public class BankOCRChallengeInput
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }

    public class BankOCRChallengeOutput
    {
        public int Id { get; set; }

        public string PrintedNumbers { get; set; }
    }
}
