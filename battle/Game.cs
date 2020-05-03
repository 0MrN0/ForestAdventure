using System;
using System.Collections.Generic;
using System.Drawing;

namespace ForestAdv.Domain
{
    public enum GameState
    {
        NotStarted,
        InForest,
        InBattle,
        GameOver
    }

    public class Game
    {
        public GameState State;
        public ForestField Forest;
        public BattleField Battle;
        public Player Hero;

        public Game(List<MonsterCamp> monsters)
        {
            State = GameState.InForest;
            Forest = new ForestField(10, 10, monsters);
            Battle = null;
            Hero = new Player();
        }

        public void MoveTo(Point point)
        {
            
        }

        public bool IsFight()
        {
            if (State != GameState.InForest) return false;
            var currentPoint = Hero.Location;
            foreach(var camp in Forest.Monsters)
                if (currentPoint == camp.Location)
                    return true;
            return false;
        }
    }
}