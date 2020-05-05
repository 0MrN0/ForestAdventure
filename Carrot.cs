﻿using System;
using System.Drawing;

namespace ForestAdventure
{
    public class Carrot
    {
        public readonly int Increment;
        public readonly Attribute Attribute;
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