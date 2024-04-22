namespace CallOfCthulu
{
    public abstract class Item
    {
        public required string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public int AttackBonus { get; set; }
    }

    public class Armor : Item
    {
        public int ArmorClass { get; set; }
    }

    public class Consumable : Item
    {
        public int Quantity { get; set; }
    }

    public class Tool : Item
    {
    }

    public class Clothing : Item
    {
    }

    public class Book : Item
    {
    }

    public class Scroll : Item
    {
    }

    public class Map : Item
    {
    }

    public class Key : Item
    {
    }

    public class LightSource : Item
    {
    }

    public class Container : Item
    {
    }

    public class MiscItem : Item
    {
    }
}