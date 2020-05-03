using System.Collections.Generic;
using System.Linq;

namespace ForestAdv.Domain
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

        public List<Creature> GetQueue() => PlayerTeam
            .Union(ComputerTeam)
            .OrderBy(x => x.Luck)
            .ToList();
    }
}