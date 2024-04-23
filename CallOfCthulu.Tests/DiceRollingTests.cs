namespace CallOfCthulu.Tests;

public class DiceRollingTests
{
    [Theory]
    [InlineData(typeof(D4))]
    [InlineData(typeof(D6))]
    [InlineData(typeof(D8))]
    [InlineData(typeof(D10))]
    [InlineData(typeof(D12))]
    [InlineData(typeof(D20))]
    [InlineData(typeof(D100))]
    public void RollDice(Type dieType)
    {
        for (int i = 0; i < 10000; i++)
        {
            Die die = (Die) Activator.CreateInstance(dieType);
            int roll = die.Roll();
            Assert.InRange(roll, 1, die.Sides);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void RollDiceMultipleTimes(int times)
    {
        for (int i = 0; i < 10000; i++)
        {
            Die die = new D6();
            int roll = die.Roll(times);
            Assert.InRange(roll, times, times * die.Sides);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void RollDiceWithModifier(int modifier)
    {
        for (int i = 0; i < 10000; i++)
        {
            Die die = new D6();
            int roll = die.Roll(1, modifier);
            Assert.InRange(roll, 1 + modifier, 6 + modifier);
        }
    }

    [Fact]
    public void RollD100WithBonusDie()
    {
        for (int i = 0; i < 10000; i++)
        {
            D100 die = new D100();
            int roll = die.RollWithBonusDie();
            Assert.InRange(roll, 1, 100);
        }
    }

    [Fact]
    public void RollD100WithPenaltyDie()
    {
        for (int i = 0; i < 10000; i++)
        {
            D100 die = new D100();
            int roll = die.RollWithPenaltyDie();
            Assert.InRange(roll, 1, 100);
        }
    }
}