string[] lines = File.ReadAllLines("f1racing.csv");
F1Racing[] data = new F1Racing[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    data[i] = new F1Racing(lines[i]);
}

Console.WriteLine($"4. feladat: F1 versenyek száma: {data.Length}");
Console.Write("Kérem a versenyző nevét: ");
string inname = Console.ReadLine();
if (WinnerNumber(inname, data) == 0)
{
    Console.WriteLine("A versenyző sosem nyert szezont!");
}
else
{
    Console.WriteLine($"A versenyző {WinnerNumber(inname, data)} szezont nyert!");
}

string[] teamnames = new string[data.Length];
int numteams = 0;
for (int i = 0; i < data.Length; i++)
{
    if (!teamnames.Contains(data[i].winnerteam))
    {
        teamnames[numteams] = data[i].winnerteam;
        numteams++;
    }
}
int dbmax = 0;
string maxname = "";
for (int i = 0; i < teamnames.Length; i++)
{
    int db = 0;
    for (int j = 0; j < data.Length; j++)
    {
        if (teamnames[i] == data[j].winnerteam)
        {
            db++;
        }
    }
    if (dbmax < db)
    {
        dbmax = db;
        maxname = teamnames[i];
    }
}
Console.WriteLine($"7. feladat: Legtöbb konstruktőri díjjal rendelkező csapat: {maxname}");

int WinnerNumber(string name, F1Racing[] data)
{
    int db = 0;
    for (int i = 0; i < data.Length; i++)
    {
        if (name == data[i].winnerpilot)
        {
            db++;
        }
    }
    return db;
}

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