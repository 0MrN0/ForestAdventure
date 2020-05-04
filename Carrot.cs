﻿using System;
using System.Drawing;

namespace ConsoleApp1
{
    public enum Attribute
    {
        Hp = 0,
        Luck = 1,
        Defence = 2,
        Strenght = 3
    }

    public class Carrot
    {
        public int Increment;
        public Attribute Attribute;
        public Point Location;

        public Carrot(Point location)
        {
           var r = new Random();
           Increment = r.Next(1, 6);
           Attribute = (Attribute) r.Next(4);
           Location = location;
        }
    }
}