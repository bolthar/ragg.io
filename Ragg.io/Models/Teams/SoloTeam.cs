using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ragg.io.Models.Teams
{
    public class SoloTeam : ITeam
    {
        Player _player;

        public SoloTeam(Player player)
        {
            _player = player;
        }

        public int BaseScoreFor(Player player)
        {
            return player == _player ? 4 : 0;
        }
    }
}
