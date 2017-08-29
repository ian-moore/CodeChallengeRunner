using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeRunner.Challenges.Shared
{
    public class CodeChallengeResult
    {

        public CodeChallengeResult(bool correct)
        {
            Correct = correct;
        }

        public bool Correct { get; set; }

        public string Message { get; set; }
    }
}
