using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ragg.io.Models.Teams
{
    public class AgainstTeam : ITeam
    {
        IEnumerable<Player> _players;

        public AgainstTeam(IEnumerable<Player> players)
        {
            _players = players;
        }

        public int BaseScoreFor(Player player)
        {
            return _players.Any(x => x == player) ? 1 : 0;
        }
    }
}
