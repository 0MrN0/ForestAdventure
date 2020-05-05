﻿using NUnit.Framework;

namespace ForestAdventure
{
    [TestFixture]
    public class CreatureTest
    {
        public Creature TestCreature;
        public Creature[] StrongEnemies;
        public Creature[] WeakEnimies;

        [SetUp]
        public void SetUp()
        {
            TestCreature = new Creature(CreatureOwner.Human,
                CreatureName.Elf, 10, 5, 20, 25);
            StrongEnemies = new[]
            {
                new Creature(CreatureOwner.Computer, CreatureName.Skeleton, 1, 0, 10, 200),
                new Creature(CreatureOwner.Computer, CreatureName.Skeleton, 1, 200, 0, 1000),
                new Creature(CreatureOwner.Computer, CreatureName.Skeleton, 1, 0, 200, 200)
            };
            WeakEnimies = new[]
            {
                new Creature(CreatureOwner.Computer, CreatureName.Skeleton, 1, 0, 0, 19),
                new Creature(CreatureOwner.Computer, CreatureName.Skeleton, 1, 1, 0, 0),
                new Creature(CreatureOwner.Computer, CreatureName.Skeleton, 1, 12, 200, 1)
            };
        }

        [Test]
        public void CloneTest()
        {
            var testCr = new Creature(TestCreature);
            Assert.AreEqual(true, TestCreature.Equals(testCr));
        }

        [TestCase(5)]
        [TestCase(-29)]
        [TestCase(0)]
        [TestCase(-1)]
        public void DeathTest(int actual)
        {
            TestCreature.Hp = actual;
            Assert.AreEqual(actual <= 0, TestCreature.IsDie);
        }

        [Test]
        public void HitWhenStrongOpponentTest()
        {
            var target = new Creature(TestCreature);
            foreach (var t in StrongEnemies)
            {
                t.Hit(target);
                Assert.LessOrEqual(target.Hp, TestCreature.Hp);
                target.Hp = TestCreature.Hp;
            }
        }
        [Test]
        public void HitWhenWeakOpponentTest()
        {
            var target = new Creature(TestCreature);
            foreach (var t in WeakEnimies)
            {
                t.Hit(target);
                Assert.GreaterOrEqual(target.Hp, TestCreature.Hp);
                target.Hp = TestCreature.Hp;
            }
        }
    }
}