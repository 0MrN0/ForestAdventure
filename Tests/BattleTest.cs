﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ForestAdventure
{
    [TestFixture]
    public class BattleTest
    {
        private BattleField battleHalfDeadTeam;
        private BattleField battleDeadTeam;
        private BattleField battleAliveTeam;
        

        [SetUp]
        public void SetUp()
        {
            var deadTeam = new List<Creature>
            {
                new Creature
                    (CreatureOwner.Computer, CreatureName.Elf, 0, 5, 25, 10)
            };
            
            var aliveTeam = new List<Creature>
            {
                new Creature
                    (CreatureOwner.Computer, CreatureName.MrTree, 5, 5, 25, 10)
            };
            
            battleHalfDeadTeam = new BattleField(aliveTeam, deadTeam);
            battleDeadTeam = new BattleField(deadTeam, deadTeam);
            battleAliveTeam = new BattleField(aliveTeam, aliveTeam);
        }


        [TestCase(new[]{-100, -5, 200})]
        [TestCase(new[]{10, 5, 100})]
        public void TestChooseTarget(int[] actual)
        {    
            var team = new List<Creature>
            {
                new Creature
                    (CreatureOwner.Computer, CreatureName.Elf, actual[0], 5, 25, 10),
                new Creature
                    (CreatureOwner.Computer, CreatureName.Penguin, actual[1], 5, 25, 10),
                new Creature
                    (CreatureOwner.Computer, CreatureName.MrTree, actual[2], 5, 25, 10)
            };

            var minHp = actual
                .Where(x => x > 0)
                .Min();
            
            Assert.AreEqual(minHp, battleAliveTeam.ChooseTarget(team).Hp);
        }
        
        [Test]
        public void TestEndBattle()
        {
            Assert.AreEqual(true, battleDeadTeam.IsEndBattle());
            Assert.AreEqual(true, battleHalfDeadTeam.IsEndBattle());
            Assert.AreEqual(false, battleAliveTeam.IsEndBattle());
        }
    }
}