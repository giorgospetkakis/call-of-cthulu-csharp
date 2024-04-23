using System.Reflection.Metadata.Ecma335;

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
        public static RollResult GetRollResult(Skill skill, int bonusDice, int penaltyDice)
            => GetRollResult(skill, Roll(skill, bonusDice, penaltyDice));

        public static RollResult GetRollResult(Skill skill, int roll)
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

        public static int GetOpposedRollResult(Skill skill1, Skill skill2, int bonusDice1, int bonusDice2, int penaltyDice1, int penaltyDice2)
        {
            int roll1 = Roll(skill1, bonusDice1, penaltyDice1);
            int roll2 = Roll(skill2, bonusDice2, penaltyDice2);

            return GetOpposedRollResult(skill1, skill2, roll1, roll2);
        }

        internal static int GetOpposedRollResult(Skill skill1, Skill skill2, int roll1, int roll2)
        {
            RollResult result1 = GetRollResult(skill1, roll1);
            RollResult result2 = GetRollResult(skill2, roll2);

            if (result1 == result2)
            {
                while(roll1 == roll2)
                {
                    roll1 = Roll(skill1, 0, 0);
                    roll2 = Roll(skill2, 0, 0);
                }

                return roll1 < roll2 ? 1 : -1;
            }
            else if (result1 > result2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        internal static int Roll(Skill skill, int bonusDice, int penaltyDice)
        {
            if (bonusDice > 0 && penaltyDice > 0)
            {
                throw new ArgumentException("Cannot have both bonus and penalty dice.");
            }

            if (bonusDice > 0)
            {
                return Dice.D100.RollWithBonusDice(bonusDice);
            }
            else if (penaltyDice > 0)
            {
                return Dice.D100.RollWithPenaltyDice(penaltyDice);
            }
            else
            {
                return Dice.D100.Roll();
            }
        }
    }
}