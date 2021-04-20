using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_project
{
    public class Hero
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Coins { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Armor> ArmorsBag { get; set; }
        public List<Fight> RandomMonsterFights { get; set; }
        public List<Fight> StrongestMonsterFights { get; set; }

        public Hero(string name, int strength, int defense, int originalHealth)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHealth = originalHealth;
            WeaponsBag = new List<Weapon>();
            ArmorsBag = new List<Armor>();
            RandomMonsterFights = new List<Fight>();
            StrongestMonsterFights = new List<Fight>();
        }

        public void ShowStats()
        {
            Console.WriteLine($"Statistics for hero {Name}:");
            Console.WriteLine($"Total Number of Fights: {RandomMonsterFights.Count + StrongestMonsterFights.Count}");
            Console.WriteLine($"Number of Random Monster Fights: {RandomMonsterFights.Count}");
            Console.WriteLine($"Number of Random Monster Fight Wins: {GetNumberOfFightsWon(RandomMonsterFights)}");
            Console.WriteLine($"Number of Random Monster Fight Losses: {RandomMonsterFights.Count - GetNumberOfFightsWon(RandomMonsterFights)}");
            Console.WriteLine($"Number of Strongest Monster Fights: {StrongestMonsterFights.Count}");
            Console.WriteLine($"Number of Strongest Monster Fight Wins: {GetNumberOfFightsWon(StrongestMonsterFights)}");
            Console.WriteLine($"Number of Strongest Monster Fight Losses: {StrongestMonsterFights.Count - GetNumberOfFightsWon(StrongestMonsterFights)}");
            Console.WriteLine($"Number of Coins: {Coins}");
            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
        }

        public void ShowInventory()
        {
            Console.WriteLine($"Inventory of hero {Name}:");
            Console.WriteLine("Weapons:");
            foreach (var weapon in WeaponsBag)
            {
                Console.WriteLine($"Name: {weapon.Name}, Power: {weapon.Power}");
            }
            Console.WriteLine("Armors:");
            foreach (var armor in ArmorsBag)
            {
                Console.WriteLine($"Name: {armor.Name}, Power: {armor.Power}");
            }
            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
        }

        public void EquipWeapon()
        {
            Random r = new Random();
            int randomNum = r.Next(0, WeaponsBag.Count);
            EquippedWeapon = WeaponsBag[randomNum];
        }

        public void EquipArmor()
        {
            Random r = new Random();
            int randomNum = r.Next(0, ArmorsBag.Count);
            EquippedArmor = ArmorsBag[randomNum];
        }
        public int GetNumberOfFightsWon(List<Fight> fights)
        {
            int total = 0;
            foreach (var fight in fights)
            {
                if (fight.Winner == PlayerType.Hero)
                    total++;
            }
            return total;
        }
        
    }


}
