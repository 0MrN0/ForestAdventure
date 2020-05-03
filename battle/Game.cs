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

        public Game(List<MonsterCamp> monsters)
        {
            State = GameState.InForest;
            Forest = new ForestField(10, 10, monsters);
            Battle = null;
        }

        public void MoveTo(Point point)
        {
            if (State == GameState.InForest && Forest.InBounds(point))
                Forest.Hero.Location = point;
        }

        public bool IsFight() =>
            State == GameState.InForest 
            && Forest.Field[Forest.Hero.Location.X, Forest.Hero.Location.Y] == ForestCell.Monster;
    }
}