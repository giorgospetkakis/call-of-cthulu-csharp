namespace CallOfCthulu
{
    public abstract class Spell
    {
        public required string Name { get; set; }
        public required int Value { get; set; }
    }

    public class AttackSpell : Spell
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public int AttackBonus { get; set; }
    }

    public class DefenseSpell : Spell
    {
        public int ArmorClass { get; set; }
    }

    public class UtilitySpell : Spell
    {
    }
}