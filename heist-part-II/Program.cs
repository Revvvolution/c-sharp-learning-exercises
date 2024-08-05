// In the Main method, create a List<IRobber> and store it in a variable named rolodex. This list will contain all possible operatives that we could employ for future heists. We want to give the user the opportunity to add new operatives to this list, but for now let's pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).


namespace heist_part_II
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker{
                    Name = "DeVante",
                    SkillLevel = 73,
                    PercentageCut = 33
                },
                new Hacker{
                    Name = "Caila",
                    SkillLevel = 15,
                    PercentageCut = 50
                },
                new LockPick{
                    Name = "Jess",
                    SkillLevel = 45,
                    PercentageCut = 15
                },
                new LockPick{
                    Name = "Brooks",
                    SkillLevel = 23,
                    PercentageCut = 10
                },
                new Muscle{
                    Name = "Barry",
                    SkillLevel = 90,
                    PercentageCut = 1
                },
                new Muscle{
                    Name = "Dan",
                    SkillLevel = 25,
                    PercentageCut = 15
                }
            };
            // creating new Bank object
            // The program should create a new bank object and randomly assign values for these properties:

            // AlarmScore (between 0 and 100)
            // VaultScore (between 0 and 100)
            // SecurityGuardScore (between 0 and 100)
            // CashOnHand (between 50,000 and 1 million)

            Bank newBank = new Bank()
            {
                AlarmScore = new Random().Next(0, 100),
                VaultScore = new Random().Next(0, 100),
                SecurityGuardScore = new Random().Next(0, 100),
                CashOnHand = new Random().Next(50000, 1000000)
            };
            // When the program starts, print out the number of current operatives in the rolodex. Then prompt the user to enter the name of a new possible crew member. Once the user has entered a name, print out a list of possible specialties and have the user select which specialty this operative has. The list should contain the following options

            // Hacker (Disables alarms)
            // Muscle (Disarms guards)
            // Lock Specialist (cracks vault)


            // Continue the above action and allow the user to enter as many crew members as they like to the rolodex until they enter a blank name before continuing.

            Console.WriteLine("Let's plan a heist!");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
            while (true)
            {

                Console.WriteLine($"Current number of operatives in rolodex: {rolodex.Count}");
                Console.WriteLine("Add a new member to our crew:");
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }
                Console.WriteLine("What is their speciality?");
                Console.WriteLine("1) Hacker (Disables alarms)");
                Console.WriteLine("2) Lock Pick (Cracks vault)");
                Console.WriteLine("3) Muscle (Disarms guards)");
                int job = int.Parse(Console.ReadLine());
                // Once the user has selected a specialty, prompt them to enter the crew member's skill level as an integer between 1 and 100. Then prompt the user to enter the percentage cut the crew member demands for each mission. Once the user has entered the crew member's name, specialty, skill level, and cut, you should instantiate the appropriate class for that crew member (based on their specialty) and they should be added to the rolodex.
                Console.WriteLine("Please enter a skill level between 1-100:");
                int skillLevel = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the percentage the crew member would get for the mission");
                int percentageCut = int.Parse(Console.ReadLine());
                if (job == 1)
                {
                    rolodex.Add(
                        new Hacker
                        {
                            Name = name,
                            SkillLevel = skillLevel,
                            PercentageCut = percentageCut

                        }
                    );
                }
                else if (job == 2)
                {
                    rolodex.Add(
                        new LockPick
                        {
                            Name = name,
                            SkillLevel = skillLevel,
                            PercentageCut = percentageCut

                        }
                    );
                }
                else if (job == 3)
                {
                    rolodex.Add(
                        new Muscle
                        {
                            Name = name,
                            SkillLevel = skillLevel,
                            PercentageCut = percentageCut

                        }
                    );
                }

            }

            newBank.Report();

            // Now that we have a clue what kind of security we're working with, we can try to built out the perfect crew.

            // Print out a report of the rolodex that includes each person's name, specialty, skill level, and cut. Include an index in the report for each operative so that the user can select them by that index in the next step. (You may want to update the IRobber interface and/or the implementing classes to be able to print out the specialty)

            // Create a new List<IRobber> and store it in a variable called crew. Prompt the user to enter the index of the operative they'd like to include in the heist. Once the user selects an operative, add them to the crew list.

            // Allow the user to select as many crew members as they'd like from the rolodex. Continue to print out the report after each crew member is selected, but the report should not include operatives that have already been added to the crew, or operatives that require a percentage cut that can't be offered.


            //creating if/else to make sure no duplicate crew members, and to make sure percentage of cut can be offered
            //to store crew who is doing the current heist
            List<IRobber> crew = new List<IRobber>();
            Console.WriteLine("Let's assemble our crew");
            while (true)
            {
                for (int i = 0; i < rolodex.Count; i++)
                {
                    
                    int percentSum = crew.Sum(x => x.PercentageCut);
                    if (!crew.Any(x => x.Name == rolodex[i].Name))
                    {
                        if(percentSum + rolodex[i].PercentageCut <= 100)
                        {
                        Console.WriteLine($"Press {i + 1} for:");
                        Console.WriteLine($"Name: {rolodex[i].Name}");
                        Console.WriteLine($"Job: {rolodex[i].Job}");
                        Console.WriteLine($"Skill Level: {rolodex[i].SkillLevel}");
                        Console.WriteLine($"Cut: {rolodex[i].PercentageCut}");
                        }
                    }
                }
                Console.WriteLine("Please select a number to add them to our crew or press to continue:");
                string pick = Console.ReadLine();
                if(pick == "")
                {
                    break;
                }
                crew.Add(rolodex[int.Parse(pick) - 1]);
            }
            Console.WriteLine("Let's rob a bank!");

            //each crew member would perform their skill on the bank
            foreach(IRobber crewMember in crew)
            {
                crewMember.PerformSkill(newBank);
            }

            if(newBank.IsSecure)
            {
                Console.WriteLine("Sad. You didn't get the money");
            }
            else
            {
                Console.WriteLine("This heist was successful.");
                Console.WriteLine("Each member's cut:");
                Console.WriteLine(newBank.CashOnHand);

                foreach(IRobber crewMember in crew)
                {
                    double cut = newBank.CashOnHand / 100 * crewMember.PercentageCut;
                    Console.WriteLine($"{crewMember.Name} would get ${cut}");
                }
                Console.WriteLine($"You were left with {newBank.CashOnHand / 100 * crew.Sum(x => x.PercentageCut)}");
            }
            // Once the user enters a blank value for a crew member, we're ready to begin the heist. Each crew member should perform his/her skill on the bank. Afterwards, evaluate if the bank is secure. If not, the heist was a success! Print out a success message to the user. If the bank does still have positive values for any of its security properties, the heist was a failure. Print out a failure message to the user.

            // If the heist was a success, print out a report of each members' take, along with how much money is left for yourself.
        }
    }
}