using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeChallengeRunner.Challenges.Shared;
using CodeChallengeRunner.Challenges.BankOCR;
using Microsoft.Extensions.Logging;

namespace CodeChallengeRunner.Controllers
{
    [Route("api/[controller]")]
    public class BankOCRController : Controller
    {
        private BankOCRChallengeRunner challengeRunner;

        public BankOCRController(BankOCRChallengeRunner runner)
        {
            challengeRunner = runner;
        }

        [HttpGet]
        public BankOCRChallengeOutput Get()
        {

            var challenge = challengeRunner.GetRandomChallenge();
            var printed = String.Join("\n", challenge.PrintedNumbers);
            return new BankOCRChallengeOutput() { Id = challenge.Id, PrintedNumbers = printed };
        }

        [HttpPost]
        public CodeChallengeResult Post([FromBody] BankOCRChallengeInput input)
        {
            var correct = challengeRunner.TestChallenge(input.Id, input.Value);
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
Parse the printed numbers into a string value. Each digit is 3 characters wide.

Respond with HTTP POST and json body of { id: $id$, value: $yourScore$ }";

            return helpText;
        }
    }
}
