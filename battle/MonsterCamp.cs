﻿using System.Collections.Generic;
using System.Drawing;

namespace ForestAdv.Domain
{
    public class MonsterCamp
    {
        public List<Creature> Monsters;
        public Point Location;

        public MonsterCamp(List<Creature> monsters, Point location)
        {
            Monsters = monsters;
            Location = location;
        }
    }
}