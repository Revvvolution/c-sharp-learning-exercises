﻿﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace plan_your_heist
{
    public class TeamMember
    {
        public string? Name { get; set; }
        public int SkillLevel { get; set; }
        public double CourageFactor { get; set; }
    };

  
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"     
                        ************************
                        *** Plan Your Heist! ***
                        ************************");

              
            // Using a Dictionary to store the team member objects with their name as the Key.
            Dictionary<string, TeamMember> team = new Dictionary<string, TeamMember>();


            // A List to store the SkillLevel Values separately
            List<int> teamSkillLevels = new List<int>();

            int bankDifficultyLevel = 100;


            while (true)
            {
                TeamMember newTeamMember = GetTeamMemberInfo();

                if (string.IsNullOrEmpty(newTeamMember.Name))
                {
                    break;
                }
                team[newTeamMember.Name] = newTeamMember; // Adding Name key to Dictionary with TeamMember object as the value
                teamSkillLevels.Add(newTeamMember.SkillLevel);  // Add SkillLevel to the separate list
                Console.WriteLine($"\n\t\t\tNew Heist Member Added:\n\t   Name: {newTeamMember.Name} , Skill Level: {newTeamMember.SkillLevel} , Courage Factor: {newTeamMember.CourageFactor}\n\n");
                
            };

            // Get the Sum of all members' skill levels
            int totalTeamSkillLevel = teamSkillLevels.Sum();


            Console.WriteLine($"\n\n\n\t\t\t***************************\n\t\t\t\tHeist Team:\n\t\t\t***************************  \n\t\t\t\t{team.Count} member(s)\n\n");
            foreach (var member in team.Values)
            {
                Console.WriteLine($"\t      {member.Name} , Skill Level: {member.SkillLevel} , Courage Factor: {member.CourageFactor}");
                
            }

            // Display the team's total skill level and compare it to the bank's difficulty level
            Console.WriteLine($"\n\n\t\t\tTotal Team Skill Level: {totalTeamSkillLevel}\n");

            Console.WriteLine("\n\t*****  Result of Attempt With Current Team:  *****\n\n");

            if (totalTeamSkillLevel >= bankDifficultyLevel)
            {
                Console.WriteLine("  Incredible heist! Successful asset acquisition.");
            }
            else
            {
                Console.WriteLine("  Failed! Errbody gone...");
            }

        }

        static TeamMember GetTeamMemberInfo()
        {
            TeamMember teamMember = new TeamMember();

            Console.WriteLine("\nEnter team member's (code)name ('ENTER' to cancel/complete):");
            teamMember.Name = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(teamMember.Name))
                {
                    return teamMember;
                }
                Console.WriteLine($"\nAlright. Now, what is {teamMember.Name}'s skill level?\n(Positive whole numbers only, please.)");
                teamMember.SkillLevel = int.Parse(Console.ReadLine()!);

                Console.WriteLine($"\n{teamMember.SkillLevel}, huh? Okay, what is {teamMember.Name}'s courage factor? (Scale = 0.0 to 2.0)");
                teamMember.CourageFactor = double.Parse(Console.ReadLine()!);

                return teamMember;
            }


        }

        
    }
}