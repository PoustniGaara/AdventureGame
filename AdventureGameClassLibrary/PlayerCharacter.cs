namespace AdventureGameClassLibrary
{
    public enum PlayerCharacterType { Warrior, Wizard, Thief }

    public class PlayerCharacter : Character
    {
        public const int DEFAULT_HP = 20;
        public int ExperiencePoints { get; set; }
        public PlayerCharacterType CharacterType { get; set; }
        public int Level { get { return ExperiencePoints / 1000 + 1; } }


        public PlayerCharacter(string name, Weapon weapon, PlayerCharacterType characterType, int hitPoints = DEFAULT_HP) : base(name, weapon, hitPoints)
        {
            Name = name;
            CharacterType = characterType;  
        }

        public override string ToString()
        {
            return $"'I'm level {Level} {CharacterType}. My name is {Name}. \nI have {HitPoints}HP, {ExperiencePoints}XP and {GetWeaponName()}'";
        }


    }
}