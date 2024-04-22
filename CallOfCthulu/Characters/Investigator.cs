namespace CallOfCthulu
{
    public class Investigator : Character
    {
        public required List<Skill> Skills { get; set; }
        public List<Item>? Items { get; set; }
        public List<Spell>? Spells { get; set; }
    }
}