﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeChallengeRunner.Challenges.Shared;
using CodeChallengeRunner.Challenges.Bowling;
using Microsoft.Extensions.Logging;

namespace CodeChallengeRunner.Controllers
{
    [Route("api/[controller]")]
    public class BowlingController : Controller
    {
        private BowlingChallengeRunner challengeRunner;
        private ILogger log;

        public BowlingController(BowlingChallengeRunner runner, ILogger<BowlingController> logger)
        {
            challengeRunner = runner;
            log = logger;
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
