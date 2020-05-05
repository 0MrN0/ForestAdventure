﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ForestAdventure
{
    public class BattleField
    {
        public readonly List<Creature> PlayerTeam;
        public readonly List<Creature> ComputerTeam;

        public BattleField(List<Creature> playerTeam, List<Creature> computerTeam)
        {
            PlayerTeam = playerTeam;
            ComputerTeam = computerTeam;
        }

        public Queue<Creature> GetQueue() => new Queue<Creature>(PlayerTeam
                                   .Union(ComputerTeam)
                                   .OrderByDescending(x => x.Luck)
                                   .ToList());

        public Creature ChooseTarget(List<Creature> team)
        {
            var minHp = int.MaxValue;
            foreach (var creature in team)
            {
                if (minHp > creature.Hp && !creature.IsDie)
                    minHp = creature.Hp;
            }

            return team.FirstOrDefault(x => x.Hp == minHp);
        }

        public bool IsEndBattle() =>
            PlayerTeam.All(creature => creature.IsDie) || ComputerTeam.All(creature => creature.IsDie);

        public void ShowHp()
        {
            var i = 0;
            Console.WriteLine("########################");
            Console.WriteLine("Human: ");
            foreach (var creature in PlayerTeam)
            {
                Console.WriteLine(i + ") " + creature.Name + ": " + creature.Hp);
                i++;
            }

            i = 0;
            Console.WriteLine("Computer: ");
            foreach (var creature in ComputerTeam)
            {
                Console.WriteLine(i + ") " +creature.Name + ": " + creature.Hp);
                i++;
            }
            Console.WriteLine("########################");
        }
    }
}