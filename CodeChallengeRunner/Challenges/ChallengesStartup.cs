using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallengeRunner.Challenges.Shared;
using CodeChallengeRunner.Challenges.Bowling;
using CodeChallengeRunner.Challenges.BankOCR;

namespace CodeChallengeRunner.Challenges
{
    public static class ChallengesStartup
    {
        public static void AddChallenges(this IServiceCollection services)
        {
            services.AddSingleton<RandomProvider>();
            services.AddSingleton<BowlingChallengeRunner>();
            services.AddSingleton<BankOCRChallengeRunner>();
        }
    }
}
