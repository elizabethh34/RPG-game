using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_project
{
    public enum PlayerType
    {
        Hero,
        Monster
    }
    public class Fight
    {
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }
        public PlayerType Winner { get; set; }

        public Fight(Hero hero, Monster monster)
        {
            Hero = hero;
            Monster = monster;
        }

        public void StartFight()
        {
            Console.WriteLine("Let's get started with the fight.");
            Console.WriteLine($"{Hero.Name} is up first.");
            Console.WriteLine("Press enter to begin.");
            Console.ReadLine();

            while (Hero.CurrentHealth > 0 && Monster.CurrentHealth > 0)
            {
                HeroTurn();
                if (Monster.CurrentHealth <= 0)
                    break;
                MonsterTurn();
            }
            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
        }
        public void HeroTurn()
        {
            Hero.EquipWeapon();
            Console.WriteLine($"{Hero.Name}'s Turn:");
            Console.WriteLine($"{Hero.Name} is equipped with a {Hero.EquippedWeapon.Name}.");
            Console.WriteLine($"Press enter to attack {Monster.Name}.");
            Console.ReadLine();

            if (Hero.EquippedWeapon.Power + Hero.Strength > Monster.Defense)
            {
                int healthLost = Hero.EquippedWeapon.Power + Hero.Strength - Monster.Defense;

                Monster.CurrentHealth -= healthLost;
                Console.WriteLine($"{Monster.Name} lost {healthLost} health points.");
                if (Monster.CurrentHealth <= 0)
                {
                    Win();
                }           
            }
            else
            {
                Console.WriteLine($"{Monster.Name} lost no health points.");
            }
        }
        public void MonsterTurn()
        {
            Hero.EquipArmor();
            Console.WriteLine($"{Monster.Name}'s Turn:");
            Console.WriteLine($"{Hero.Name} is equipped with a {Hero.EquippedArmor.Name}.");
            Console.WriteLine($"Press enter to defend against {Monster.Name}.");
            Console.ReadLine();

            if (Hero.EquippedArmor.Power + Hero.Defense < Monster.Strength)
            {
                int healthLost = Monster.Strength - (Hero.EquippedArmor.Power + Hero.Defense);
                if (Hero.Coins <= healthLost && Hero.Coins > 0)
                {
                    Console.WriteLine($"Using {Hero.Name}'s {Hero.Coins} coins toward health.");
                    healthLost -= Hero.Coins;
                    Hero.Coins = 0;                    
                }
                else if (Hero.Coins > healthLost)
                {
                    Console.WriteLine($"Using {healthLost} coins toward health.");
                    Hero.Coins -= healthLost;
                    healthLost = 0;                   
                }

                Hero.CurrentHealth -= healthLost;
                Console.WriteLine($"{Hero.Name} lost {healthLost} health points.");
                if (Hero.CurrentHealth <= 0)
                {
                    Lose();
                }         
            }
            else
            {
                Console.WriteLine($"{Hero.Name} lost no health points.");
            }
        }
        public void Win()
        {
            Winner = PlayerType.Hero;
            Hero.Coins += 20;
            Console.WriteLine($"You Won! You earned 20 coins! {Monster.Name} has no more health points. {Hero.Name} still has {Hero.CurrentHealth}.");
        }
        public void Lose()
        {
            Winner = PlayerType.Monster;
            Console.WriteLine($"You Lost: {Hero.Name} has no more health points. {Monster.Name} still has {Monster.CurrentHealth}.");
        }
    }
}
