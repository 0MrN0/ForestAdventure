using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            if (State == GameState.InForest && Forest.InBounds(point))
                Hero.Location = point;
        }

        public bool IsFight() => State == GameState.InForest
                                 && Forest.Monsters.Any(camp => Hero.Location == camp.Location);
    }
}