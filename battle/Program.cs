using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ForestAdv.Domain;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var slimes = new List<Creature>
            {
                new Creature(CreatureName.Slime, 200, 70, 10, 30),
                new Creature(CreatureName.Slime, 200, 70, 10, 30),
                new Creature(CreatureName.Slime, 200, 70, 10, 30)
            };

            var skeletons = new List<Creature>
            {
                new Creature(CreatureName.Skeleton, 150, 30, 0, 70),
                new Creature(CreatureName.Skeleton, 150, 30, 0, 70),
                new Creature(CreatureName.Skeleton, 150, 30, 0, 70)
            };
            
            var skeletonCamp = new MonsterCamp(skeletons, new Point(2, 2));
            var slimeCamp = new MonsterCamp(slimes, new Point(5, 5));
            
            var game = new Game(new List<MonsterCamp>{skeletonCamp, slimeCamp});

            while (true)
            {
                Console.WriteLine("game: " + game.State);
                Console.WriteLine("hero in (" + game.Hero.Location + ")");
                Console.WriteLine("Choose point to move or print 'exit' to exit");
                
                var args = Console.ReadLine().Split(' ');
                if (args[0] == "exit")
                {
                    Console.WriteLine("GameOver");
                    break;
                }
                
                var point = new Point(Int32.Parse(args[0]), Int32.Parse(args[1]));
                
                if (!game.Forest.InBounds(point))
                {
                    Console.WriteLine("Hero cant move");
                    continue;
                }

                game.MoveTo(point);

                if (game.IsFight())
                {
                    Console.WriteLine("hero is fighting");
                }
            }
        }
    }
}