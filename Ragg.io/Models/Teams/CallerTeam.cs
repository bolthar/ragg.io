using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ragg.io.Models.Teams
{
    public class CallerTeam : ITeam
    {
        Player _caller;
        Player _socio;

        public CallerTeam(Player caller, Player socio)
        {
            _caller = caller;
            _socio = socio;
        }

        public int BaseScoreFor(Player player)
        {
            if (player == _caller) return 2;
            if (player == _socio) return 1;
            return 0;
        }

    }
}
