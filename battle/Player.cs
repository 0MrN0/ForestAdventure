using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ForestAdv.Domain
{
    public class Player
    {
        public Point Location;
        public List<Creature> DreamTeam;

        public Player()
        {
            Location = new Point {X = 0, Y = 0};
            DreamTeam = new List<Creature>();
            DreamTeam.Append(new Creature(CreatureName.Elf, 350, 50, 15, 75));
        }
    }

}