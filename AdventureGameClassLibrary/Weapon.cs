 namespace AdventureGameClassLibrary
{
    public class Weapon
    {
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        Random random = new Random();


        public Weapon(string name, int maximumDamage)
        {
            Name = name;
            MaximumDamage = maximumDamage;
        }

        public int GetDamage()
        {   
            return random.Next(MaximumDamage) +1;
        }


    }
}
