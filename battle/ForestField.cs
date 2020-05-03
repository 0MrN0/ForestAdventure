using System.Collections.Generic;
using System.Drawing;

namespace ForestAdv.Domain
{
    public class ForestField
    {
        public Point[,] Field;
        public List<MonsterCamp> Monsters;

        public ForestField(int height, int width, List<MonsterCamp> monsters)
        {
            Field = new Point[width, height];
            for(var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                Field[i, j] = new Point{X = i, Y = j};
            Monsters = monsters;
        }

        public int Width => Field.GetLength(0);
        public int Height => Field.GetLength(1);

        public bool InBounds(Point location)
            => location.X >= 0 && location.Y >= 0 && location.X < Width && location.Y < Height;
    }
}