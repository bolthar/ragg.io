using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ragg.io.Models
{
    public class Game : IGame
    {
        private ITeam _winningTeam;
        private ITeam _losingTeam;
        private int _multiplier;
        private IGame _previousGame;

        public Game(ITeam winningTeam, ITeam losingTeam, int multiplier, IGame previousGame)
        {
            _winningTeam = winningTeam;
            _losingTeam = losingTeam;
            _multiplier = multiplier;
            _previousGame = previousGame;
        }
        
        public int ScoreFor(Player player)
        {
            int baseScore = _previousGame.ScoreFor(player);
            return baseScore +
                (
                    (_winningTeam.BaseScoreFor(player) + (-1 * _losingTeam.BaseScoreFor(player)))
                 * _multiplier);                 
        }
    }

    public class NoPreviousGame : IGame
    {   
        public int ScoreFor(Player player)
        {
            return 0;
        }
    }

    public interface IGame
    {
        int ScoreFor(Player player);
    }
}
