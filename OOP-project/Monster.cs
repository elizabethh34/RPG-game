using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_project
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Monster(string name, int strength, int defense, int originalHealth)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHealth = originalHealth;
        }
    }
}
