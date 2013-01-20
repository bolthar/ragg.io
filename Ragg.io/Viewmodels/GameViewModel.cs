using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ragg.io.Views;
using Ragg.io.Models;

namespace Ragg.io.Viewmodels
{
    public class GameViewModel : BaseViewModel<GameView>
    {
        public IGame Game { get; private set; }
        public IEnumerable<ScoreViewModel> Scores { get; private set; }

        public IEnumerable<ScoreView> ScoreViews
        {
            get { return Scores.Select(x => x.View); }
        }

        public GameViewModel(GameView view, IGame game, IEnumerable<Player> players, bool isLast, bool isAlternate) : base(view)
        {
            Game = game;
            var scores = new List<ScoreViewModel>();
            foreach (var player in players)
            {
                scores.Add(new ScoreViewModel(new ScoreView(), game.ScoreFor(player), isLast, isAlternate)); 
            }
            Scores = scores;
            Notify(() => ScoreViews);
        }
    }
}
