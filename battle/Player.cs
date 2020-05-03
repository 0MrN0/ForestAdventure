using System.Drawing;
using System.Reflection.Metadata;

namespace ForestAdv.Domain
{
    public class Player
    {
        public Point Location;

        public Player()
        {
            Location = new Point {X = 0, Y = 0};
        }
    }

}