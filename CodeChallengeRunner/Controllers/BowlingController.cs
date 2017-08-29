using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeChallengeRunner.Challenges.Shared;
using CodeChallengeRunner.Challenges.Bowling;
    

namespace CodeChallengeRunner.Controllers
{
    [Route("api/[controller]")]
    public class BowlingController : Controller
    {
        private BowlingChallengeRunner challengeRunner;

        public BowlingController(BowlingChallengeRunner runner)
        {
            challengeRunner = runner;
        }
        
        [HttpGet]
        public BowlingChallengeOutput Get()
        {
            var challenge = challengeRunner.GetRandomChallenge();
            return new BowlingChallengeOutput() { Id = challenge.Id, Frames = challenge.Frames };
        }
        
        [HttpPost]
        public CodeChallengeResult Post([FromBody] BowlingChallengeInput input)
        {
            var correct = challengeRunner.TestChallenge(input.Id, input.Score);
            var result = new CodeChallengeResult(correct);

            if (!correct)
            {
                result.Message = "Score was incorrect.";
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

            return result;
        }

        [HttpGet("help")]
        public string Help()
        {
            var helpText = @"
Return the score for the bowling game defined in the provided frames.

Respond with HTTP POST and json body of { id: $id$, score: $yourScore$ }";

            return helpText;
        }
    }
}
