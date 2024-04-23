namespace CallOfCthulu
{
    public enum RollResult
    {
        CriticalFailure,
        Failure,
        Success,
        HardSuccess,
        ExtremeSuccess,
        CriticalSuccess
    }

    public static class Core
    {
        internal static int OpposedRoll((Skill skill, int roll) roll1, (Skill skill, int roll) roll2)
        {
            RollResult result1 = Roll(roll1.skill, roll1.roll);
            RollResult result2 = Roll(roll2.skill, roll2.roll);
            
            if (result1 > result2)
            {
                return 1;
            }
            else if (result1 < result2)
            {
                return -1;
            }
            else
            {
                int extraRoll1;
                int extraRoll2;

                do
                {
                    extraRoll1 = Dice.D100.Roll();
                    extraRoll2 = Dice.D100.Roll();
                }
                while(extraRoll1 == extraRoll2);

                return extraRoll1 > extraRoll2 ? 1 : -1;
            }
        }

        public static RollResult Roll(Skill skill, int bonusDice, int penaltyDice)
        {
            if (bonusDice > 0 && penaltyDice > 0)
            {
                throw new ArgumentException("Cannot have both bonus and penalty dice.");
            }

            if (bonusDice > 0)
            {
                int roll = Dice.D100.RollWithBonusDice(bonusDice);
                return Roll(skill, roll);
            }
            else if (penaltyDice > 0)
            {
                int roll = Dice.D100.RollWithPenaltyDice(penaltyDice);
                return Roll(skill, roll);
            }
            else
            {
                int roll = Dice.D100.Roll();
                return Roll(skill, roll);
            }
        }

        internal static RollResult Roll(Skill skill, int roll)
        {
            if ((skill.Value >= 50 && roll == 100) || (skill.Value < 50 && roll >= 96))
            {
                return RollResult.CriticalFailure;
            }
            else if (roll == 1)
            {
                return RollResult.CriticalSuccess;
            }
            else if (roll <= skill.Value / 5)
            {
                return RollResult.ExtremeSuccess;
            }
            else if (roll <= skill.Value / 2)
            {
                return RollResult.HardSuccess;
            }
            else if (roll <= skill.Value)
            {
                return RollResult.Success;
            }
            else if (roll > skill.Value)
            {
                return RollResult.Failure;
            }
            else
            {
                throw new Exception($"Could not determine roll result for skill {skill} and roll {roll}.");
            }
        }
    }
}