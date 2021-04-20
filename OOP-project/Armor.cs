using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_project
{
    public class Armor
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Armor(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
