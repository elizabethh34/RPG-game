using System;
using System.Collections.Generic;
//OOP Project
//Elizabeth Hellsten

namespace OOP_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int health = 100;

            List<Monster> monsters = new List<Monster>()
            {
                new Monster("Rampage", 165, 150, health),
                new Monster("Destructo", 175, 180, health),
                new Monster("Crusher", 160, 145, health),
                new Monster("Wrecker", 180, 180, health),
                new Monster("Smasher", 170, 160, health)
            };

            List<Weapon> weapons = new List<Weapon>()
            {
                new Weapon("Knife", 45),
                new Weapon("Sword", 120),
                new Weapon("Club", 80),
                new Weapon("Hammer", 55),
                new Weapon("Bow and Arrow", 100)
            };

            List<Armor> armors = new List<Armor>()
            {
                new Armor("Shield", 80),
                new Armor("Helmet", 55),
                new Armor("Vest", 40),
                new Armor("Guard", 70),
                new Armor("Blocker", 35)
            };
            game.FillMonstersList(monsters);
            game.Start(weapons, armors, 100, 100, health);
        }
    }
}
