namespace CallOfCthulu.Tests;

public class SkillCheckTests
{
    [Theory]
    [InlineData(1, 1, RollResult.CriticalSuccess)]
    [InlineData(1, 2, RollResult.Failure)]
    [InlineData(1, 96, RollResult.CriticalFailure)]
    [InlineData(25, 1, RollResult.CriticalSuccess)]
    [InlineData(25, 5, RollResult.ExtremeSuccess)]
    [InlineData(25, 12, RollResult.HardSuccess)]
    [InlineData(25, 25, RollResult.Success)]
    [InlineData(25, 50, RollResult.Failure)]
    [InlineData(25, 96, RollResult.CriticalFailure)]
    [InlineData(50, 1, RollResult.CriticalSuccess)]
    [InlineData(50, 5, RollResult.ExtremeSuccess)]
    [InlineData(50, 25, RollResult.HardSuccess)]
    [InlineData(50, 50, RollResult.Success)]
    [InlineData(50, 96, RollResult.Failure)]
    [InlineData(50, 100, RollResult.CriticalFailure)]
    [InlineData(75, 1, RollResult.CriticalSuccess)]
    [InlineData(75, 15, RollResult.ExtremeSuccess)]
    [InlineData(75, 37, RollResult.HardSuccess)]
    [InlineData(75, 75, RollResult.Success)]
    [InlineData(75, 96, RollResult.Failure)]
    [InlineData(75, 100, RollResult.CriticalFailure)]
    public void Roll(int skillValue, int roll, RollResult expected)
    {
        Skill skill = new MockSkill(skillValue);
        RollResult result = Core.GetRollResult(skill, roll);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void OpposedRoll_WithRandomRolls()
    {
        for (int i = 0; i < 10000; i++)
        {
            Skill skill1 = new MockSkill(50);
            Skill skill2 = new MockSkill(50);
            int result = Core.GetOpposedRollResult(skill1, skill2, 0, 0, 0, 0);
            Assert.InRange(result, -1, 1);
        }
    }

    [Theory]
    [InlineData(1, 1, 1, 2, 1)]
    [InlineData(1, 1, 2, 1, -1)]
    [InlineData(25, 25, 24, 25, 1)]
    [InlineData(25, 25, 25, 24, -1)]
    [InlineData(50, 50, 1, 50, 1)]
    [InlineData(50, 50, 5, 50, 1)]
    [InlineData(50, 50, 25, 50, 1)]
    [InlineData(50, 50, 49, 50, 1)]
    [InlineData(50, 50, 50, 49, -1)]
    [InlineData(50, 50, 50, 25, -1)]
    [InlineData(50, 50, 50, 5, -1)]
    [InlineData(50, 50, 50, 1, -1)]
    public void OpposedRoll_WithFixedRolls(int skill1Value, int skill2Value, int roll1, int roll2, int expected)
    {
        Skill skill1 = new MockSkill(skill1Value);
        Skill skill2 = new MockSkill(skill2Value);
        int result = Core.GetOpposedRollResult(skill1, skill2, roll1, roll2);
        Assert.Equal(expected, result);
    }
}

public class MockSkill : Skill
{
    public MockSkill(int value) => Value = value;
    public override string Name => "Mock Skill";
    public override int Value { get; set; }
}
