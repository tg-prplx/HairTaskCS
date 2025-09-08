namespace HairSim;

struct Hair
{
    public int Length;
    public int LifeTime;
}

class HairSim
{
    private readonly Random _rnd = new Random();
    private readonly short CanToDeadTime = 60; // days
    private readonly double MinRangeMod = 0.05;
    private readonly double MaxRangeMod = 0.1;
    private List<Hair> Hairs = Enumerable.Repeat(new Hair { Length = 0, LifeTime = 0 }, 100000).ToList();
    private readonly int[] GrowthRange = {3, 6};
    private readonly double UnexpectedDropProb = 0.01;

    public List<Hair> GetHairs() => Hairs;

    private short GetRndMMInDay()
    {
        return (short)_rnd.Next(GrowthRange[0], GrowthRange[1]);
    }

    private void GrowHairByDay()
    {
        for (int i = 0; i < Hairs.Count; i++)
        {
            var hair = Hairs[i];
            hair.Length += GetRndMMInDay();
            hair.LifeTime++;
            Hairs[i] = hair;
        }
    }

    private void KillSomeRandomHairs()
    {
        for (int i = 0; i < Hairs.Count; i++)
        {
            if (Hairs[i].Length != 0 && _rnd.NextDouble() < UnexpectedDropProb)
            {
                Hairs[i] = new Hair { Length = 0, LifeTime = 0 };
            }
        }
    }

    private HashSet<int> GetDiedIndices(int readyToDieCount, List<int> readyToDieIndices)
    {
        var diedIndices = new HashSet<int>();
        var n = readyToDieIndices.Count;

        if (readyToDieCount > n)
        {
            readyToDieCount = n;
        }

        for (var i = 0; i < readyToDieCount; i++)
        {
            var randPos = _rnd.Next(i, n);
            var selectedIdx = readyToDieIndices[randPos];

            diedIndices.Add(selectedIdx);

            var temp = readyToDieIndices[i];
            readyToDieIndices[i] = readyToDieIndices[randPos];
            readyToDieIndices[randPos] = temp;
        }
        return diedIndices;
    }

    private void RemoveRandomHairsSim()
    {
        var readyToDieIndices = new List<int>();
        for (int i = 0; i < Hairs.Count; i++)
        {
            if (Hairs[i].LifeTime > CanToDeadTime)
                readyToDieIndices.Add(i);
        }
        if (readyToDieIndices.Count == 0) return;

        var minKill = (int)(MinRangeMod * readyToDieIndices.Count);
        var maxKill = (int)(MaxRangeMod * readyToDieIndices.Count);
        int readyToDieCount;
        if (minKill >= maxKill)
        {
            readyToDieCount = minKill;
        }
        else
        {
            readyToDieCount = _rnd.Next(minKill, maxKill);
        }

        if (readyToDieCount > readyToDieIndices.Count)
        {
            readyToDieCount = readyToDieIndices.Count;
        }

        if (readyToDieCount == 0) return;

        var diedIndices = GetDiedIndices(readyToDieCount, readyToDieIndices);

        foreach (int idx in diedIndices)
        {
            Hairs[idx] = new Hair { Length = 0, LifeTime = 0 };
        }
        KillSomeRandomHairs();
    }

    public void StartSim(int days)
    {
        for (int day = 0; day < days; day++)
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
        int daysToSim = 10000;
        var hairSim = new HairSim();
        hairSim.StartSim(daysToSim);
        var hairs = hairSim.GetHairs();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Hair {i}: len = {hairs[i].Length}, age = {hairs[i].LifeTime}");
        }
    }
}


