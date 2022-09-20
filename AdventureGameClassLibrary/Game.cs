using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameClassLibrary
{
    public class Game
    {
        public MonsterCharacter MonsterCharacter { get; set; }
        public PlayerCharacter PlayerCharacter { get; set; }
        public Boolean PlayerWonFight { get; set; }
        public Boolean MonsterWonFight { get; set; }
        public Boolean FightIsFinished { get; set; }
        public Boolean GameIsFinished { get; set; }
        public String[] MonsterNames = { "Thunderfoot", "Shadowfiend", "Gloomface", "The Mad Ooze" };
        public String[] PlayerNames = {"Garen", "Jarvan IV", "Darius", "Kayle"};
        public String[] WeaponNames = { "Fast Dagger", "Old Bow", "Golden Sword", "Obsidian Spear" };
        public int[] WeaponDamage = { 2, 3, 4, 5 };
        Random random = new Random();
        StringBuilder roundStatus = new StringBuilder();
        

        public Game()
        {
            PlayerCharacter = GenerateRandomPlayerCharacter();
            MonsterCharacter = GenerateRandomMonsterCharacter();
        }

        public void PlayRound()
        {
            roundStatus.Clear();

            string playerAttackInfo;
            string monsterAttackInfo;

            int playerDamage = PlayerCharacter.Attack();
            int monsterDamage = MonsterCharacter.Attack();

            if (playerDamage >= MonsterCharacter.HitPoints)
            {
                MonsterCharacter.HitPoints -= playerDamage;
                PlayerWonFight = true;
                FightIsFinished = true;
                int preFightLevel = PlayerCharacter.Level;
                PlayerCharacter.ExperiencePoints += 200;
                playerAttackInfo = $"\n{PlayerCharacter.Name} hit {MonsterCharacter.Name} for {playerDamage}hp \n{MonsterCharacter.Name} has {MonsterCharacter.HitPoints}hp left";
                if (preFightLevel < PlayerCharacter.Level) { roundStatus.Append($"\nCONGRATULATIONS you are level {PlayerCharacter.Level} now!"); }
                roundStatus.Append(playerAttackInfo);
                return;
            }
            if(monsterDamage >= PlayerCharacter.HitPoints)
            {
                MonsterWonFight = true;
                FightIsFinished = true;
                MonsterCharacter.HitPoints -= playerDamage;
                PlayerCharacter.HitPoints -= monsterDamage;
                playerAttackInfo = $"\n{PlayerCharacter.Name} hit {MonsterCharacter.Name} for {playerDamage}hp \n{MonsterCharacter.Name} has {MonsterCharacter.HitPoints}hp left";
                monsterAttackInfo = $"\n{MonsterCharacter.Name} hit {PlayerCharacter.Name} for {monsterDamage}hp \n{PlayerCharacter.Name} has {PlayerCharacter.HitPoints}hp left";
                roundStatus.Append(playerAttackInfo + monsterAttackInfo);
                GameIsFinished = true;
                return;
            }

            MonsterCharacter.HitPoints -= playerDamage;
            PlayerCharacter.HitPoints -= monsterDamage;
            playerAttackInfo = $"\n{PlayerCharacter.Name} hit {MonsterCharacter.Name} for {playerDamage}hp\n{MonsterCharacter.Name} has {MonsterCharacter.HitPoints}hp left";
            monsterAttackInfo = $"\n{MonsterCharacter.Name} hit {PlayerCharacter.Name} for {monsterDamage}hp\n{PlayerCharacter.Name} has {PlayerCharacter.HitPoints}hp left";
            roundStatus.Append(playerAttackInfo + monsterAttackInfo);

        }

        public string GetRoundStatus()
        {
            return roundStatus.ToString();
        }

        public MonsterCharacter GenerateRandomMonsterCharacter()
        {
            int monsterNameID = random.Next(0, MonsterNames.Length);
            string name = MonsterNames[monsterNameID];
            int hitPoints = random.Next(10) + 1;
            Array values = Enum.GetValues(typeof(MonsterType));
            MonsterType randomMonsterType = (MonsterType)values.GetValue(random.Next(values.Length));

            return MonsterCharacter = new MonsterCharacter(MonsterNames[monsterNameID], GenerateRandomWeapon(), hitPoints, randomMonsterType);

        }

        public PlayerCharacter GenerateRandomPlayerCharacter()
        {
            int playerNameID = random.Next(0, PlayerNames.Length);
            string name = PlayerNames[playerNameID];
            Array values = Enum.GetValues(typeof(PlayerCharacterType));
            PlayerCharacterType randomPlayerCharacterType = (PlayerCharacterType)values.GetValue(random.Next(values.Length));

            return PlayerCharacter = new PlayerCharacter(name, GenerateRandomWeapon(), randomPlayerCharacterType);
        }

        public Weapon GenerateRandomWeapon()
        {
            int i = random.Next(0, WeaponNames.Length);
            return new Weapon(WeaponNames[i], WeaponDamage[i]);
        }
    }
}
