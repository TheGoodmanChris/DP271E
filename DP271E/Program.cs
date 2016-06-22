using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//This program is a solution to this challenge: https://www.reddit.com/r/dailyprogrammer/comments/4nvrnx/20160613_challenge_271_easy_critical_hit/
//Critical hits work a bit differently in this RPG.If you roll the maximum value on a die, you get to roll the die again and add both dice rolls to get your final score.Critical hits can stack indefinitely -- a second max value means you get a third roll, and so on.With enough luck, any number of points is possible.
//
//Input
//
//d -- The number of sides on your die.
//h -- The amount of health left on the enemy.
//Output
//
//The probability of you getting h or more points with your die.

namespace DP271E
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assert.AreEqual(1f, ProbabilityOfKilling(4, 1));
                Assert.AreEqual(0.25f, ProbabilityOfKilling(4, 4));
                Assert.AreEqual(0.25f, ProbabilityOfKilling(4, 5));
                Assert.AreEqual(0.1875f, ProbabilityOfKilling(4, 6));
                Assert.AreEqual(1f, ProbabilityOfKilling(1, 10));
                Assert.AreEqual(0.0001f, ProbabilityOfKilling(100, 200));
                Assert.AreEqual(0.009765625f, ProbabilityOfKilling(8, 20));

                Console.WriteLine("Woot! Success!");
            }
            catch(AssertFailedException)
            {
                Console.WriteLine("Failed!");
            }
            Console.ReadLine();
        }

        private static float ProbabilityOfKilling(int die, int health)
        {
            if (health <= die)
                return 1f - ((health - 1f) / die);
            else
                return (1f / die) * ProbabilityOfKilling(die, health - die);
        }
    }
}
