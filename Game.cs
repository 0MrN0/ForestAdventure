﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ForestAdventure
{
    public class Game
    {
        public GameState State;
        public ForestField Forest;
        public BattleField Battle;
        
        public Game()
        {
            State = GameState.NotStarted;
            Forest = null;
            Battle = null;
        }
        
        public void CheckHero()
        {
            if (State == GameState.InBattle && Battle.PlayerTeam.All(x => x.IsDie))
                State = GameState.HeroDie;
        }

        public void CheckMonsters()
        {
            if (Forest.Monsters.Count == 0)
                State = GameState.MonstersDie;
        }

        public void InitForestField()
        {
            var slime = new Creature
                (CreatureOwner.Computer, CreatureName.Slime, 200, 5, 10, 15);
            var skeleton = new Creature
                 (CreatureOwner.Computer, CreatureName.Skeleton, 150, 70, 0, 5);
            var penguin = new Creature
                 (CreatureOwner.Computer, CreatureName.Penguin, 250, 5, 25, 10);

            var team1 = new List<Creature> {new Creature(slime), new Creature(skeleton), new Creature(slime)};
            var team2 = new List<Creature> {new Creature(penguin), new Creature(slime), new Creature(penguin)};
            var team3 = new List<Creature> {new Creature(skeleton), new Creature(penguin), new Creature(skeleton)};

            var camps = new HashSet<MonsterCamp>
            {
                new MonsterCamp(team1, new Point(3, 0)),
                new MonsterCamp(team2, new Point(4, 1)),
                new MonsterCamp(team3, new Point(1, 4))
            };
            
            var carrots = new HashSet<Carrot>
            {
                new Carrot(new Point(0, 2)),
                new Carrot(new Point(0, 4)),
                new Carrot(new Point(4, 0))
            };
            
            var walls = new HashSet<Point>
            {
                new Point(1, 0),
                new Point(1, 2),
                new Point(1, 3),
                new Point(0, 3),
                new Point(3, 1),
                new Point(3, 3),
            };

            State = GameState.InForest;
            Forest = new ForestField(10, 10, camps, carrots, walls);
        }

        public void InitBattle()
        {
            State = GameState.InBattle;
            Battle = new BattleField(Forest.Hero.DreamTeam, Forest.GetMonstersFromCamp());
        }

        public void GetStats()
        {
            Console.WriteLine("########################");
            foreach (var creature in Forest.Hero.DreamTeam)
            {
                Console.WriteLine
                (creature.Name + ":" + '\n'
                 + "Hp: " + creature.Hp + '\n'
                 + "Luck: " + creature.Luck + '\n'
                 + "Defence: " + creature.Defence + '\n'
                 + "Strength: " + creature.Strength + '\n');
                Console.WriteLine();
            }
            Console.WriteLine("########################");
        }
    }
}
//               хп, лак, рег, тычка
// Эльф:		750, 50, 15, 75
// Кролик:		750, 40, 35, 50
// Енот:		450, 100, 5, 100
// Кошак:		1000, 0, 50, 0
//
// Пингвин:	    250, 5, 25, 10
// Слайм:		200, 5, 10, 15
// Скелет:		150, 70, 0, 5
//
// Гюнтер:		500, 50, 10, 50
// ДеРеВо:		1000, 10, 50, 5
// Некромант:	750, 75, 0, 75