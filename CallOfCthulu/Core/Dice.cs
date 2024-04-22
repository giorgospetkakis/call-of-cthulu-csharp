namespace CallOfCthulu
{
    public static class Dice
    {
        public static D4 D4 => new D4();
        public static D6 D6 => new D6();
        public static D8 D8 => new D8();
        public static D10 D10 => new D10();
        public static D12 D12 => new D12();
        public static D20 D20 => new D20();
        public static D100 D100 => new D100();
    }
    
    public abstract class Die
    {
        public int Sides { get; set; }
        public int Roll() => new Random().Next(1, Sides + 1);
        public int Roll(int times) => Roll(times, 0);
        public int Roll(int times, int modifier) => Enumerable.Range(0, times).Sum(result => Roll()) + modifier;
    }

    public class D4 : Die
    {
        public D4() => Sides = 4;
    }

    public class D6 : Die
    {
        public D6() => Sides = 6;
    }

    public class D8 : Die
    {
        public D8() => Sides = 8;
    }

    public class D10 : Die
    {
        public D10() => Sides = 10;
    }

    public class D12 : Die
    {
        public D12() => Sides = 12;
    }

    public class D20 : Die
    {
        public D20() => Sides = 20;
    }

    public class D100 : Die
    {
        public D100() => Sides = 100;
        public int RollWithBonusDie()
        {
            var tens1 = Roll() % 10;
            var tens2 = Roll() % 10;
            var ones = Roll();
            return Math.Max(tens1, tens2) * 10 + ones;
        }

        public int RollWithPenaltyDie()
        {
            var tens1 = Roll() % 10;
            var tens2 = Roll() % 10;
            var ones = Roll();
            return Math.Min(tens1, tens2) * 10 + ones;
        }
    }
}