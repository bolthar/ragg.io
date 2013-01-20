using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ragg.io.Views;
using Ragg.io.Models;

namespace Ragg.io.Viewmodels
{
    public class GamesViewModel : BaseViewModel<GamesView>
    {
        public IEnumerable<GameViewModel> Games { get; private set; }

        public IEnumerable<GameView> GameViews
        {
            get { return Games.Select(x => x.View); }
        }

        public GamesViewModel(GamesView view, IEnumerable<IGame> games, IEnumerable<Player> players) : base(view)
        {
            Games = games.Select(x => new GameViewModel(new GameView(), x, players, games.Last() == x, games.ToList().IndexOf(x) % 2 == 0)).ToList();
            Notify(() => GameViews);
        }

        public IGame LastGame
        {
            get
            {
                return Games != null && Games.LastOrDefault() != null ? Games.Last().Game : (IGame)new NoPreviousGame();
            }
        }
    }
}
