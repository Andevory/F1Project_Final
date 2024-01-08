string[] lines = File.ReadAllLines("f1racing.csv");
F1Racing[] data = new F1Racing[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    data[i] = new F1Racing(lines[i]);
}

Console.WriteLine($"4. feladat: F1 versenyek száma: {data.Length}");

struct F1Racing
{
    public int seasonnum;
    public string winnerpilot;
    public string winnerteam;
    public int numofraces;
    public int numofracers;
    public int numofteams;
    public F1Racing(string line)
    {
        var splitted = line.Split(';');
        this.seasonnum = int.Parse(splitted[0]);
        this.winnerpilot = splitted[1];
        this.winnerteam = splitted[2];
        this.numofraces = int.Parse(splitted[3]);
        this.numofracers = int.Parse(splitted[4]);
        this.numofteams = int.Parse(splitted[5]);
    }
}