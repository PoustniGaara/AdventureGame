namespace AdventureGameClassLibrary
{
    public abstract class Character
    {
        internal static Random random = new Random();
        #region Properties
        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public int HitPoints { get; set; }
        public Boolean IsAlive { get { return HitPoints > 0; } }
        public int Gold { get; set; } = random.Next(25);


        #endregion

        public Character(string name, Weapon weapon, int hitPoints = 20)
        {
            Name = name;
            Weapon = weapon;
            HitPoints = hitPoints;
        }

        public int Attack()
        {
            if(Weapon == null) { return 1; }
            return Weapon.GetDamage();
        }

        protected string GetWeaponName()
        {
            string weaponName = "no weapon";
            if (Weapon != null) { weaponName = $"a {Weapon.Name}"; }
            return weaponName;
        }

    }
}
