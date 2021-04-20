using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_project
{
    public enum MenuType
    {
        Main,
        Fight
    }
    public class Game
    {
        public string Name { get; set; }
        public Hero Hero { get; set; }
        public List<Monster> Monsters { get; set; }
        public Monster CurrentMonster { get; set; }

        public Game()
        {
            Monsters = new List<Monster>();
        }

        public void Start(List<Weapon> weapons, List<Armor> armors, int heroStrength, int heroDefense, int health)
        {
            string name = GetUsersName();
            Hero hero = new Hero(name, heroStrength, heroDefense, health);
            Hero = hero;
            FillHeroWeaponsBag(weapons);
            FillHeroArmorsBag(armors);

            int selection = GetMenuSelection(MenuType.Main);
            while (selection != 4)
            {               
                HandleMainMenuSelection(selection);
                selection = GetMenuSelection(MenuType.Main);
            }            
        }
        public string GetUsersName()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            while (name == "")
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();
            }
            Console.WriteLine($"Thank you {name}, press enter to begin the game!");
            Console.ReadLine();
            return name;
        }
        public void ShowMainMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Show Statistics");
            Console.WriteLine("2. Show Inventory");
            Console.WriteLine("3. Fight!");
            Console.WriteLine("4. Exit Game");
        }
        public int GetMenuSelection(MenuType menuType)
        {
            HashSet<int> selectionOptions;
            
            if (menuType == MenuType.Fight)
            {
                ShowFightOptions();
                selectionOptions = new HashSet<int>() { 1, 2 };
            }
            else
            {
                ShowMainMenu();
                selectionOptions = new HashSet<int>() { 1, 2, 3, 4 };
            }           
            
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int selection);
            while (!selectionOptions.Contains(selection))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out selection);
            }
            Console.WriteLine("Thank you");
            return selection;
        }
        public void HandleMainMenuSelection(int selection)
        {
            switch (selection)
            {
                case 1:
                    Hero.ShowStats();
                    break;
                case 2:
                    Hero.ShowInventory();
                    break;
                case 3:
                    StartNewFight();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }
        public void ShowFightOptions()
        {
            Console.WriteLine("You chose Fight! Please select an option:");
            Console.WriteLine("1. Fight a Random Monster");
            Console.WriteLine("2. Fight the Strongest Monster");
        }
        public void StartNewFight()
        {
            int selection = GetMenuSelection(MenuType.Fight);
            bool IsStrongestFight = false;

            switch (selection)
            {
                case 1:
                    SetRandomCurrentMonster();
                    break;
                case 2:
                    SetStrongestMonster(Monsters);
                    IsStrongestFight = true;
                    break;
                default:
                    Console.WriteLine("Invalid Selection.");
                    break;
            }
            
            Hero.CurrentHealth = Hero.OriginalHealth;
            CurrentMonster.CurrentHealth = CurrentMonster.OriginalHealth;
            Fight newFight = new Fight(Hero, CurrentMonster);

            if (IsStrongestFight)
            {
                Hero.StrongestMonsterFights.Add(newFight);
            }
            else
            {
                Hero.RandomMonsterFights.Add(newFight);
            }

            newFight.StartFight();
        }       
        public void SetRandomCurrentMonster()
        {
            Random r = new Random();
            int randomNum = r.Next(0, Monsters.Count);
            CurrentMonster = Monsters[randomNum];
        }
        public void SetStrongestMonster(List<Monster> monsters)
        {
            Monster strongestMonster = null;
            int strongest = 0;
            foreach (var monster in monsters)
            {
                int totalStrength = monster.Defense + monster.Strength;
                if (totalStrength > strongest)
                {
                    strongest = totalStrength;
                    strongestMonster = monster;
                }
            }
            CurrentMonster = strongestMonster;
        }
        public void FillMonstersList(List<Monster> monsters)
        {
            foreach (var monster in monsters)
            {
                Monsters.Add(monster);
            }
        }
        public void FillHeroWeaponsBag(List<Weapon> weapons)
        {
            foreach (var weapon in weapons)
            {
                Hero.WeaponsBag.Add(weapon);
            }
        }
        public void FillHeroArmorsBag(List<Armor> armors)
        {
            foreach (var armor in armors)
            {
                Hero.ArmorsBag.Add(armor);
            }
        }
    }
}
