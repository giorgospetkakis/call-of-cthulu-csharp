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

    public enum RollType
    {
        Normal,
        BonusDie,
        PenaltyDie
    }

    public static class Core
    {
        public static RollResult Roll(Skill skill, RollType type)
            => type switch 
            {
                RollType.Normal => Roll(skill, Dice.D100.Roll()),
                RollType.BonusDie => Roll(skill, Dice.D100.RollWithBonusDie()),
                RollType.PenaltyDie => Roll(skill, Dice.D100.RollWithPenaltyDie()),
                _ => throw new Exception($"Could not determine roll type for {type}.")
            };

        static RollResult Roll(Skill skill, int roll)
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
                return RollResult.CriticalSuccess;
            }
            else if (roll <= skill.Value / 2)
            {
                return RollResult.ExtremeSuccess;
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