﻿using System.Collections.Generic;
using System.Drawing;

namespace ForestAdventure
{
    public class Player
    {
        public Point Location;
        public List<Creature> DreamTeam;

        public Player()
        {
            Location = new Point {X = 0, Y = 0};
            DreamTeam = new List<Creature>
            {
                (new Creature(CreatureOwner.Human, CreatureName.Elf, 750, 50, 15, 75)),
                (new Creature(CreatureOwner.Human, CreatureName.LittleCat, 750, 40, 35, 50)),
                (new Creature(CreatureOwner.Human, CreatureName.Raccoon, 450, 100, 5, 100)),
                (new Creature(CreatureOwner.Human, CreatureName.Rabbit, 1000, 0, 50, 0))
            };
        }
    }

}