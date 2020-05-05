﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ForestAdventure
{
    public class ForestField
    {
        public readonly Point[,] Field;
        public HashSet<MonsterCamp> Monsters;
        public Player Hero;
        public HashSet<Carrot> Carrots;
        public readonly HashSet<Point> Walls;
        public HashSet<Note> Notes;

        public ForestField
            (int height, int width, HashSet<MonsterCamp> monsters, HashSet<Carrot> carrots, HashSet<Point> walls)
        {
            Field = new Point[width, height];
            for(var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                Field[i, j] = new Point{X = i, Y = j};

            Notes = new HashSet<Note>
            {
                new Note(new Point(4, 4), "ITS GUNTER", Boss.Gunter),
                new Note(new Point(-1, -1), "ITS TREE", Boss.MrTree),
                new Note(new Point(-1, -1), "ITS NECROMANCER", Boss.Necromancer)
            };
            
            Monsters = monsters;
            Hero = new Player();
            Carrots = carrots;
            Walls = walls;
        }

        public int Width => Field.GetLength(0);
        public int Height => Field.GetLength(1);

        public bool CanMove(Point location)
            => location.X >= 0 && location.Y >= 0 
                               && location.X < Width && location.Y < Height 
                               && !Walls.Contains(location);

        public void MoveTo(int dx, int dy)
        {
            var point = new Point(Hero.Location.X + dx, Hero.Location.Y + dy);
            if (CanMove(point))
                Hero.Location = point;
        }
        
        public bool IsMonster() => Monsters.Any(camp => Hero.Location == camp.Location);
        public bool IsCarrot() => Carrots.Any(carrot => Hero.Location == carrot.Location);

        public bool IsNote() => Notes.Any(note => Hero.Location == note.Location);

        public List<Creature> GetMonstersFromCamp() 
            => Monsters.FirstOrDefault(camp => Hero.Location == camp.Location)?.Monsters;

        public Carrot GetCarrotFromLocation()
            => Carrots.FirstOrDefault(carrot => carrot.Location == Hero.Location);

        public Note GetNoteFromLocation()
            => Notes.FirstOrDefault(note => note.Location == Hero.Location);
        
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

        public void ReadNote()
        {
            var note = GetNoteFromLocation();
            switch (note.BossToOpen)
            {
                case Boss.Gunter:
                    var gunterTeam = new List<Creature>
                    {
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Penguin, 250, 5, 25, 10),
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Gunter, 500, 50, 10, 50),
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Penguin, 250, 5, 25, 10)
                    };
                    Monsters.Add(new MonsterCamp(gunterTeam, new Point(2, 2)));
                    break;
                case Boss.MrTree:
                    var treeTeam = new List<Creature>
                    {
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Slime, 200, 5, 10, 15),
                        new Creature
                            (CreatureOwner.Computer, CreatureName.MrTree, 1000, 10, 50, 5),
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Slime, 200, 5, 10, 15)
                    };
                    Monsters.Add(new MonsterCamp(treeTeam, new Point(0, 0)));
                    break;
                case Boss.Necromancer:
                    var necroTeam = new List<Creature>
                    {
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Skeleton, 150, 70, 0, 5),
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Necromancer, 750, 75, 0, 75),
                        new Creature
                            (CreatureOwner.Computer, CreatureName.Skeleton, 150, 70, 0, 5)
                    };
                    Monsters.Add(new MonsterCamp(necroTeam, new Point(0, 0)));
                    break;
            }

            Notes.Remove(note);
        }

        public void RemoveCurrentMonsterCamp()
            => Monsters.Remove(Monsters.FirstOrDefault(x => x.Location == Hero.Location));
    }
}