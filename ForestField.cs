﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApp1
{
    public class ForestField
    {
        public Point[,] Field;
        public HashSet<MonsterCamp> Monsters;
        public Player Hero;
        public HashSet<Carrot> Carrots;

        public ForestField
            (int height, int width, HashSet<MonsterCamp> monsters, HashSet<Carrot> carrots)
        {
            Field = new Point[width, height];
            for(var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                Field[i, j] = new Point{X = i, Y = j};
            
            Monsters = monsters;
            Hero = new Player();
            Carrots = carrots;
        }

        public int Width => Field.GetLength(0);
        public int Height => Field.GetLength(1);

        public bool InBounds(Point location)
            => location.X >= 0 && location.Y >= 0 && location.X < Width && location.Y < Height;

        public bool IsFight() => Monsters.Any(camp => Hero.Location == camp.Location);
        public bool IsCarrot() => Carrots.Any(carrot => Hero.Location == carrot.Location);
        
        public void MoveTo(Point point)
        {
            if (InBounds(point))
                Hero.Location = point;
        }
        
        public List<Creature> GetMonstersFromCamp() 
            => Monsters.FirstOrDefault(camp => Hero.Location == camp.Location)?.Monsters;

        public Carrot GetCarrotFromLocation()
            => Carrots.FirstOrDefault(carrot => carrot.Location == Hero.Location);

        public void EatCarrot()
        {
            var carrot = GetCarrotFromLocation();
            switch (carrot?.Attribute)
            {
                case Attribute.Defence:
                    foreach (var creature in Hero.DreamTeam)
                        creature.Defence += carrot.Increment;
                    break;
                case Attribute.Hp:
                    foreach (var creature in Hero.DreamTeam)
                        creature.Hp += carrot.Increment * 10; 
                    break;
                case Attribute.Strenght:
                    foreach (var creature in Hero.DreamTeam)
                        creature.Strength += carrot.Increment; 
                    break;
                case Attribute.Luck:
                    foreach (var creature in Hero.DreamTeam)
                        creature.Luck += carrot.Increment + 5; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Carrots.Remove(carrot);
        }

        public void RemoveCurrentMonsterCamp()
            => Monsters.Remove(Monsters.FirstOrDefault(x => x.Location == Hero.Location));
    }
}