// Take the Bank parameter and decrement its appropriate security score by the SkillLevel. i.e. A Hacker with a skill level of 50 should decrement the bank's AlarmScore by 50.
// Print to the console the name of the robber and what action they are performing. i.e. "Mr. Pink is hacking the alarm system. Decreased security 50 points"
// If the appropriate security score has be reduced to 0 or below, print a message to the console, i.e. "Mr Pink has disabled the alarm system!"

public class Muscle : IRobber
{
    public string Name {get; set;}
    public int SkillLevel {get; set;}
    public int PercentageCut {get; set;}
    public string Job {get;} = "Muscle";
    public void PerformSkill(Bank bank)
    {
        bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
        Console.WriteLine($"{Name} is punching the security guards. Decreased security guard {SkillLevel} points");
        if(bank.AlarmScore <= 0)
        {
            Console.WriteLine($"{Name} has punched all the security guards!");
        }
    }
}