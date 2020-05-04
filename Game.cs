﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApp1
{
    public enum GameState
    {
        NotStarted,
        InForest,
        InBattle,
        HeroDie,
        MonstersDie
    }

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
                (CreatureOwner.Computer, CreatureName.Slime, 200, 70, 10, 30);
            var skeleton = new Creature
                 (CreatureOwner.Computer, CreatureName.Skeleton, 150, 30, 0, 70);
            var penguin = new Creature
                 (CreatureOwner.Computer, CreatureName.Penguin, 250, 0, 0, 40);
            var gunter = new Creature
                (CreatureOwner.Computer, CreatureName.Gunter, 500, 50, 10, 50);
            var mrTree = new Creature
                (CreatureOwner.Computer, CreatureName.MrTree, 1000, 10, 50, 10);
            var necromancer = new Creature
                (CreatureOwner.Computer, CreatureName.Necromancer, 750, 75, 20, 75);

            var team1 = new List<Creature> {new Creature(slime), new Creature(skeleton), new Creature(slime)};
            var team2 = new List<Creature> {new Creature(penguin), new Creature(slime), new Creature(penguin)};
            var team3 = new List<Creature> {new Creature(skeleton), new Creature(penguin), new Creature(skeleton)};
            var gunBoss = new List<Creature> {new Creature(penguin), gunter, new Creature(penguin)};
            var treeBoss = new List<Creature> {new Creature(slime), mrTree, new Creature(slime)};
            var necroBoss = new List<Creature> {new Creature(skeleton), necromancer, new Creature(skeleton)};

            var camps = new HashSet<MonsterCamp>
            {
                new MonsterCamp(team1, new Point(5, 1)),
                //new MonsterCamp(team2, new Point(1, 3)),
                // new MonsterCamp(team3, new Point(8, 2)),
                // new MonsterCamp(gunBoss, new Point(8, 8)),
                // new MonsterCamp(treeBoss, new Point(1, 7)),
                // new MonsterCamp(necroBoss, new Point(5, 4))
            };
            
            var carrots = new HashSet<Carrot>
            {
                new Carrot(new Point(7, 2)),
                new Carrot(new Point(0, 4)),
                new Carrot(new Point(4, 5)),
                new Carrot(new Point(0, 9)),
                new Carrot(new Point(9, 9))
            };
            
            State = GameState.InForest;
            Forest = new ForestField(10, 10, camps, carrots);
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
//               хп, лак, деф, тычка
// Эльф:		350, 50, 15, 75
// Кролик:		450, 40, 35, 50
// Енот:		100, 100, 0, 100
// Кошак:		666, 0, 50, 0
//
// Пингвин:	    250, 30, 25, 40
// Слайм:		200, 70, 10, 30
// Скелет:		150, 30, 0, 70
//
// Гюнтер:		500, 50, 10, 50
// ДеРеВо:		1000, 10, 50, 10
// Некромант:	750, 75, 20, 75