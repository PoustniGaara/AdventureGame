using AdventureGameClassLibrary;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Threading;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void PlayerLevelProperty()
        {
            //Arrange
            Weapon weapon = new Weapon("Hoe", 2);
            string name = "Greg";
            PlayerCharacterType characterType = PlayerCharacterType.Warrior;

            PlayerCharacter character0XP = new PlayerCharacter(name, weapon, characterType);
            PlayerCharacter character999XP = new PlayerCharacter(name, weapon, characterType);
            PlayerCharacter character1000XP = new PlayerCharacter(name, weapon, characterType);
            PlayerCharacter character1999XP = new PlayerCharacter(name, weapon, characterType);

            character999XP.ExperiencePoints = 999;
            character1000XP.ExperiencePoints = 1000;
            character1999XP.ExperiencePoints = 1999;

            //Act
            int lvlA = character0XP.Level;
            int lvlB = character999XP.Level;
            int lvlC = character1000XP.Level;
            int lvlD = character1999XP.Level;


            //Assert
            Assert.AreEqual(1, lvlA, "Level is not correct");
            Assert.AreEqual(1, lvlB, "Level is not correct");
            Assert.AreEqual(2, lvlC, "Level is not correct");
            Assert.AreEqual(2, lvlD, "Level is not correct");

        }

        [Test]
        public void PlayerCharacterConstruction()
        {
            //Arrange
            Weapon weapon = new Weapon("Hoe", 2);
            string name = "Greg";
            PlayerCharacterType characterType = PlayerCharacterType.Warrior;

            //Act
            PlayerCharacter character = new PlayerCharacter(name, weapon, characterType);

            //Assert
            Assert.IsNotNull(character, "character is null");
            Assert.AreEqual("Greg", character.Name, "Name is not correct");
            Assert.AreEqual(weapon, character.Weapon, "weapon is not correct");
            Assert.AreEqual(PlayerCharacterType.Warrior, character.CharacterType, "Type is not correct");

        }

        [Test]
        public void MonsterCharacterConstruction()
        {
            //Arrange
            Weapon weapon = new Weapon("Axe", 4);
            string name = "Baltazar";
            MonsterType monsterType = MonsterType.Ogre;
            int hitPoints = 10;

            //Act
            MonsterCharacter monster = new MonsterCharacter(name, weapon, hitPoints, monsterType);

            //Assert
            Assert.IsNotNull(monster, "monster is null");
            Assert.AreEqual(name, monster.Name, "Name is not correct");
            Assert.AreEqual(weapon, monster.Weapon, "weapon is not correct");
            Assert.AreEqual(monsterType, monster.MonsterType, "Type is not correct");
            Assert.AreEqual(hitPoints, monster.HitPoints, "HitPoints is not correct");
        }

        [Test]
        public void AlivePropertyBooleanReturn()
        {
            //Arrange
            Weapon weapon = new Weapon("Hoe", 2);
            string name = "Greg";
            PlayerCharacterType characterType = PlayerCharacterType.Warrior;
            int hitPoints = 10;
            int hitPoints2 = -1;

            //Act
            PlayerCharacter characterAlive = new PlayerCharacter(name, weapon, characterType, hitPoints);
            PlayerCharacter characterDead = new PlayerCharacter(name, weapon, characterType, hitPoints2);

            //Assert
            Assert.AreEqual(true, characterAlive.IsAlive, "Should return true");
            Assert.AreEqual(false, characterDead.IsAlive, "Should return true");

        }

        [Test]
        public void getDamage()
        {
            //Arrange
            int numberOfAttacks = 10000;
            int actualTotalDamage = 0;
            int expectedTotalDamage = 50000;
            Weapon weapon = new Weapon("Sword", 10);


            //Act
            for(int i = 0; i < numberOfAttacks; i++)
            {
                actualTotalDamage += weapon.GetDamage();
            }

            int damageDifference =  Math.Abs(expectedTotalDamage - actualTotalDamage);
            //Assert

            Assert.IsTrue(damageDifference < 10000, "Should return true");

        }


    }
}