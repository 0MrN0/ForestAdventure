﻿using System.Collections.Generic;
using System.Drawing;

namespace ForestAdventure
{
    public class MonsterCamp
    {
        public readonly List<Creature> Monsters;
        public Point Location;

        public MonsterCamp(List<Creature> monsters, Point location)
        {
            Monsters = monsters;
            Location = location;
        }
    }
}