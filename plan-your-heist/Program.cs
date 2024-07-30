﻿using System;
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

            Dictionary<string, TeamMember> team = new Dictionary<string, TeamMember>();


            while (true)
            {
                TeamMember newTeamMember = GetTeamMemberInfo();

                if (string.IsNullOrEmpty(newTeamMember.Name))
                {
                    break;
                }
                team[newTeamMember.Name] = newTeamMember;
                Console.WriteLine($"\n\t\t\tNew Heist Member Added:\n\t   Name: {newTeamMember.Name} , Skill Level: {newTeamMember.SkillLevel} , Courage Factor: {newTeamMember.CourageFactor}\n\n");
            };

            Console.WriteLine($"\n\n\n\t\t\t***************************\n\t\t\t\tHeist Team:\n\t\t\t***************************  \n\t\t\t\t{team.Count} member(s)\n\n");
            foreach (var member in team.Values)
            {
                Console.WriteLine($"\t      {member.Name} , Skill Level: {member.SkillLevel} , Courage Factor: {member.CourageFactor}");
                
            }

        }
        static TeamMember GetTeamMemberInfo()
        {
            TeamMember teamMember = new TeamMember();

            Console.Write("\nEnter team member's (code)name ('ENTER' to cancel): ");
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