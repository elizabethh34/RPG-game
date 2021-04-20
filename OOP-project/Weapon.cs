using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_project
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Weapon(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
