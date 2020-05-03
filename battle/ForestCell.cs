using System.Collections.Generic;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace ForestAdv.Domain
{
    public enum ForestCell
    {
        Empty,
        Monster
    }

    public class ForestField
    {
        public ForestCell[,] Field;
        public Player Hero;
        public List<MonsterCamp> Monsters;

        public ForestField(int height, int width, List<MonsterCamp> monsters)
        {
            Field = new ForestCell[width, height];
            Hero = new Player();
            Monsters = monsters;
        }

        public int Width => Field.GetLength(0);
        public int Height => Field.GetLength(1);

        public bool InBounds(Point location)
            => location.X >= 0 && location.Y >= 0 && location.X < Width && location.Y < Height;
    }
}