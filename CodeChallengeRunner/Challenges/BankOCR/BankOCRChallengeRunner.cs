using CodeChallengeRunner.Challenges.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeRunner.Challenges.BankOCR
{
    // From: http://codingdojo.org/kata/BankOCR/
    public class BankOCRChallengeRunner
    {
        private RandomProvider random;

        public BankOCRChallengeRunner(RandomProvider randomProvider)
        {
            random = randomProvider;
        }

        private Dictionary<int,BankOCRChallenge> challenges = new Dictionary<int,BankOCRChallenge>
        {
            { 1, new BankOCRChallenge() {
                    Id = 1,
                    Value = "123456789",
                    PrintedNumbers = new string[] {
                        "    _  _     _  _  _  _  _ ",
                        "  | _| _||_||_ |_   ||_||_|",
                        "  ||_  _|  | _||_|  ||_| _|"
                    }
                }
            },
            { 2, new BankOCRChallenge() {
                    Id = 1,
                    Value = "000000000",
                    PrintedNumbers = new string[] {
                        " _  _  _  _  _  _  _  _  _ ",
                        "| || || || || || || || || |",
                        "|_||_||_||_||_||_||_||_||_|", }
                    }
            },
            { 2, new BankOCRChallenge() {
                    Id = 1,
                    Value = "777777777",
                    PrintedNumbers = new string[] {
                        " _  _  _  _  _  _  _  _  _ ",
                        "  |  |  |  |  |  |  |  |  |",
                        "  |  |  |  |  |  |  |  |  |", }
                    }
            }
        };

        public BankOCRChallenge GetRandomChallenge()
        {
            var randomId = random.GetRandom(1, challenges.Keys.Count);
            return challenges[randomId];
        }
        
        public bool TestChallenge(int id, string testValue)
        {
            return testValue == challenges[id].Value;
        }
    }
}
