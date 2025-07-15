namespace HairSim;
class HairSim
{
    private readonly Random rnd = new Random();
    private readonly short CanToDeadTime = 60; // days
    private readonly double MinRangeMod = 0.05;
    private readonly double MaxRangeMod = 0.1;
    private List<int> HairsLength = Enumerable.Repeat(0, 100000).ToList();
    private List<int> HairsLifeTime = Enumerable.Repeat(0, 100000).ToList();
    private readonly int[] GrowthRange = {3, 6};
    private readonly double UnexpectedDropProb = 0.01;

    public List<int> GetHairsLength() => HairsLength;
    public List<int> GetHairsLifeTime() => HairsLifeTime;

    private short GetRndMMInDay()
    {
        return (short)rnd.Next(GrowthRange[0], GrowthRange[1]);
    }

    private void GrowHairByDay()
    {
        for (int i = 0; i < HairsLength.Count; i++) 
        {
            HairsLength[i] += GetRndMMInDay();
            HairsLifeTime[i]++;
        }
    }

    private void KillSomeRandomHairs()
    {
        for (int i = 0; i < HairsLength.Count; i++)
        {
            if (HairsLength[i] != 0 && rnd.NextDouble() < UnexpectedDropProb)
            {
                HairsLength[i] = 0;
                HairsLifeTime[i] = 0;
            }
        }
    }

    private HashSet<int> GetDiedIndices(int ReadyToDieCount, List<int> ReadyToDieIndices)
    {
        HashSet<int> DiedIndices = new HashSet<int>();
        while (DiedIndices.Count < ReadyToDieCount)
        {
            int randPos = rnd.Next(ReadyToDieIndices.Count);
            int idx = ReadyToDieIndices[randPos];
            DiedIndices.Add(idx);
        }
        return DiedIndices;
    }

    private void RemoveRandomHairsSim()
    {
        List<int> ReadyToDieIndices = new List<int>();
        for (int i = 0; i < HairsLifeTime.Count; i++)
        {
            if (HairsLifeTime[i] > CanToDeadTime)
                ReadyToDieIndices.Add(i);
        }
        if (ReadyToDieIndices.Count == 0) return;

        int[] range = { (int)(MinRangeMod * ReadyToDieIndices.Count), (int)(MaxRangeMod * ReadyToDieIndices.Count) };        
        short ReadyToDieCount = (short)rnd.Next(range[0], range[1]);

        var DiedIndices = GetDiedIndices(ReadyToDieCount, ReadyToDieIndices);

        foreach (int idx in DiedIndices)
        {
            HairsLength[idx] = 0;
            HairsLifeTime[idx] = 0;
        }
        KillSomeRandomHairs();
    }

    public void StartSim(int days)
    {
        for (int i = 0;i < days; i++)
        {
            GrowHairByDay();
            RemoveRandomHairsSim();
        }
    }
}

class Program
{
    static void Main()
    {
        int DaysToSim = 10000;
        var HairS = new HairSim();
        HairS.StartSim(DaysToSim);
        var HairsLength = HairS.GetHairsLength();
        var HairsLifeTime = HairS.GetHairsLifeTime();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Hair {i}: len = {HairsLength[i]}, age = {HairsLifeTime[i]}");
        }
    }
}


