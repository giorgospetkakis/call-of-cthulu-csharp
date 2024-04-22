namespace CallOfCthulu;

public abstract class Character
{
    public required string Name { get; set; }
    public bool HasMajorWound { get; set; }
    public int Age { get; set; }
    public int HitPoints { get; set; }
    public int MaxHitPoints { get; set; }
    public int Sanity { get; set; }
    public int MaxSanity { get; set; }
    public bool IsPermanentlyInsane => Sanity <= 0;
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Power { get; set; }
    public int Constitution { get; set; }
    public int Appearance { get; set; }
    public int Education { get; set; }
    public int Size { get; set; }
    public int Intelligence { get; set; }
    public int MoveRate { get; set; }
    public int DamageBonus { get; set; }
    public int Build { get; set; }
    public int Dodge { get; set; }
}
