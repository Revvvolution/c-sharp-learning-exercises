public class Bank
{
    public int CashOnHand { get; set; }
    public int AlarmScore { get; set; }
    public int VaultScore { get; set; }
    public int SecurityGuardScore { get; set; }
    public bool IsSecure
    {
        get
        {
            if (AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // Let's do a little recon next. Print out a Recon Report to the user. This should tell the user what the bank's most secure system is, and what its least secure system is (don't print the actual integer scores--just the name, i.e. Most Secure: Alarm Least Secure: Vault
    public void Report()
    {
        Dictionary<string, int> values = new Dictionary<string, int>();
        
        values.Add("Alarm", AlarmScore);
        values.Add("Vault", VaultScore);
        values.Add("Guards", SecurityGuardScore);

        // var Scores = from score in values orderby score.Value ascending select score;
        var scores = values.OrderBy(x => x.Value);
        List<KeyValuePair<string, int>> keyValuePairs = scores.ToList();

        Console.WriteLine($"Most Secure: {keyValuePairs[-1].Key}");
        Console.WriteLine($"Least Secure:{keyValuePairs[0].Key}");

    }
}