namespace AdventureGameClassLibrary
{
    public enum MonsterType { Orc, Ogre, Goblin, Troll }

    public class MonsterCharacter : Character
    {
        public MonsterType MonsterType { get; set; }


        public MonsterCharacter(string name, Weapon weapon, int hitPoints, MonsterType monsterType) : base(name, weapon, hitPoints)
        {
            MonsterType = monsterType;
            Gold = random.Next(25) + 1;

        }

        public override string ToString()
        {
            return $"'I'm a {MonsterType}. My name is {Name}. I have {HitPoints} hp and {GetWeaponName()}.'";
        }
    }
}
