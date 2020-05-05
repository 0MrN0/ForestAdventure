﻿using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;

namespace ForestAdventure
{
    public class ForestFieldsTest
    {
        private int height;
        private int width;
        private ForestField testField;

        [SetUp]
        public void SetUp()
        {
            height = 100;
            width = 200;
            testField = new ForestField(height, width,
                new HashSet<MonsterCamp>(),
                new HashSet<Carrot>(),
                new HashSet<Point>());
        }

        [Test]
        public void CanMoveWithOutWallsTest()
        {
            var bounds = new Rectangle(0, 0, testField.Width, testField.Height);
            var rnd = new Random();
            for (var i = 0; i < 1000; i++)
            {
                var testPoint = new Point(rnd.Next(0, 2 * height), rnd.Next(0, 2 * width));
                Assert.AreEqual(bounds.Contains(testPoint),
                    testField.CanMove(testPoint));
            }
        }

        [Test]
        public void CanMoveWithWallsTest()
        {
            var bounds = new Rectangle(0, 0, testField.Width, testField.Height);
            var rnd = new Random();
            AddWalls();
            for (var i = 0; i < 1000; i++)
            {
                var testPoint = new Point(rnd.Next(0, 2 * height), rnd.Next(0, 2 * width));
                Assert.AreEqual(bounds.Contains(testPoint) && !testField.Walls.Contains(testPoint),
                    testField.CanMove(testPoint));
            }
        }

        [Test]
        public void MoveToWithOutWallsTest()
        {
            var rnd = new Random();
            for (var i = 0; i < 1000; i++)
            {
                var deltaPoint = new Point(rnd.Next(0, 2 * height), rnd.Next(0, 2 * width));
                var prevPoint = testField.Hero.Location;
                var point = new Point(prevPoint.X + deltaPoint.X, prevPoint.Y + deltaPoint.Y);
                if (!testField.CanMove(point)) continue;
                testField.MoveTo(deltaPoint.X, deltaPoint.Y);
                Assert.AreEqual(point,
                    testField.Hero.Location);
            }
        }

        [Test]
        public void MoveToWithWallsTest()
        {
            var rnd = new Random();
            AddWalls();
            for (var i = 0; i < 1000; i++)
            {
                var deltaPoint = new Point(rnd.Next(0, 2 * height), rnd.Next(0, 2 * width));
                var prevPoint = testField.Hero.Location;
                var point = new Point(prevPoint.X + deltaPoint.X, prevPoint.Y + deltaPoint.Y);
                if (!testField.CanMove(point)) continue;
                testField.MoveTo(deltaPoint.X, deltaPoint.Y);
                Assert.AreEqual(point,
                    testField.Hero.Location);
            }
        }

        private void AddWalls()
        {
            var rnd = new Random();
            for (var i = 0; i < height / 2; i++)
            for (var j = 0; j < width / 2; j++)
                testField.Walls.Add(new Point(rnd.Next(0, i), rnd.Next(0, j)));
        }
    }
}