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

            TeamMember newTeamMember = GetTeamMemberInfo();
            

            Console.WriteLine($"\n\t\t\tNew Heist Team:\n\n {newTeamMember.Name} , Skill Level: {newTeamMember.SkillLevel} , Courage Factor: {newTeamMember.CourageFactor}");

        }
        static TeamMember GetTeamMemberInfo()
        {
            TeamMember teamMember = new TeamMember();

            Console.Write("\nEnter team member's name (use a codename if possible): ");
            teamMember.Name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"\nAlright. Now, what is {teamMember.Name}'s skill level?\n(Positive whole numbers only, please.)");
            teamMember.SkillLevel = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"\n{teamMember.SkillLevel}, huh? Okay, what is {teamMember.Name}'s courage factor? (Scale = 0.0 to 2.0)");
            teamMember.CourageFactor = double.Parse(Console.ReadLine()!);

            return teamMember;

        }

        
    }
}