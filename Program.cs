﻿using System;
using System.Collections.Generic;

namespace BankHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, TeamMember> TheSquad = new();

            while (true)
            {
                Console.WriteLine("Plan Your Heist");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _");
                Console.WriteLine("");

                Console.WriteLine("What is your team member's name");
                TeamMember TeamMember = new();
                string givenName = Console.ReadLine();
                TeamMember.Name = givenName;
                Console.WriteLine("");
                if (TeamMember.Name == "")
                {
                    break;
                }

                Console.WriteLine("What is your team members skill level? (1-25)");
                string memberSkillLevel = Console.ReadLine();
                int memberSkillInt = int.Parse(memberSkillLevel);
                while (memberSkillInt < 0 || memberSkillInt > 25)
                {
                    Console.WriteLine("Invalid response, try again.");
                    memberSkillLevel = Console.ReadLine();
                    memberSkillInt = int.Parse(memberSkillLevel);
                }
                TeamMember.SkillLevel = memberSkillInt;
                Console.WriteLine($"Team member Skill Level set to: {TeamMember.SkillLevel}");
                Console.WriteLine("");

                Console.WriteLine("What is your team members courage level? (decimal between 0.0-1.0)");
                string memberCourageLevel = Console.ReadLine();
                float memberCourageInt = float.Parse(memberCourageLevel);
                while (memberCourageInt < 0.0 || memberCourageInt > 1.0)
                {
                    Console.WriteLine("Invalid response, try again.");
                    memberCourageLevel = Console.ReadLine();
                    memberCourageInt = int.Parse(memberCourageLevel);
                }
                TeamMember.CourageFactor = memberCourageInt;
                Console.WriteLine($"Team member Courage Level set to: {TeamMember.CourageFactor}");
                Console.WriteLine("");

                TheSquad.Add(givenName, TeamMember);
                // Console.WriteLine($"{TeamMember.Name} has a skill level of {TeamMember.SkillLevel} and a courage factor of {TeamMember.CourageFactor}");
                Console.WriteLine("");

            }

            Console.WriteLine("How many times would you like to run this simulation? (1-5)");
            string trialRuns = Console.ReadLine();
            int trialRunsInt = int.Parse(trialRuns);

            int bankDifficulty = 100;
            int teamSkillLevel = 0;

            for (int i = 0; i < trialRunsInt; i++)
            {
                Random r = new Random();
                int luckValue = r.Next(-10, 11);

                bankDifficulty += luckValue;

                foreach (KeyValuePair<string, TeamMember> member in TheSquad)
                {
                    teamSkillLevel += member.Value.SkillLevel;
                }

                Console.WriteLine($"You team's skill level is {teamSkillLevel}. The bank's difficulty level is {bankDifficulty}.");

                if (teamSkillLevel >= bankDifficulty)
                {
                    Console.WriteLine("You robbed the crap out of that bank");
                }
                else
                {
                    Console.WriteLine("Wow you got caught so fast");
                }
            }

        }
    }
}
