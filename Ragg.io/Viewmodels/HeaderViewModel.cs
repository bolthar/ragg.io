using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ragg.io.Views;
using Ragg.io.Models;
using System.Windows;
using Ragg.io.Models.Teams;

namespace Ragg.io.Viewmodels
{
    public class HeaderViewModel : BaseViewModel<HeaderView>
    {
        public event Action<IEnumerable<PlayerViewModel>> SetPlayers;
        public event Action<ITeam, ITeam, int> AddGame;

        private IList<PlayerViewModel> _players = new List<PlayerViewModel>();

        public ControlsViewModel Controls { get; private set; }

        public IEnumerable<FrameworkElement> PlayersViews
        {
            get { return _players.Select(x => x.View).ToList(); }
        }
        
        public HeaderViewModel(HeaderView view, IList<PlayerViewModel> players) : base(view)
        {
            View.Add += new Action<String>(View_Add);
            _players = players;
            foreach (var player in _players)
            {
                player.ValidationChanged += player_ValidationChanged;
                player.Reset();
            }
            Controls = new ControlsViewModel(new ControlsView(), false);
            Controls.AddGame += new Action<int, bool>(Controls_AddGame);
            Notify(() => Controls);
            Notify(() => PlayersViews);
        }

        void Controls_AddGame(int arg1, bool arg2)
        {
            Player caller = _players.First(x => x.Chiamata).Player;
            Player socio = _players.First(x => x.Socio).Player;
            IEnumerable<Player> against = _players
                .Where(x => !x.Morto && x.Player != caller && x.Player != socio)
                .Select(x => x.Player).ToList();
            ITeam callerTeam = caller == socio ? (ITeam)new SoloTeam(caller) : new CallerTeam(caller, socio);
            ITeam againstTeam = new AgainstTeam(against);
            if (arg2)
            {
                AddGame(callerTeam, againstTeam, arg1);
            }
            else
            {
                AddGame(againstTeam, callerTeam, arg1);
            }
            SetPlayers(_players);
        }

        void player_ValidationChanged()
        {
            if(Controls != null) Controls.IsStateValid = isPlayerStatusValid();
        }

        bool isPlayerStatusValid()
        {
            bool oneChiamata = _players.Where(x => x.Chiamata).Count() == 1;
            bool oneSocio = _players.Where(x => x.Socio).Count() == 1;
            bool exactlyFiveActivePlayers = _players.Where(x => !x.Morto).Count() == 5;
                return oneChiamata &&
                oneSocio &&
                exactlyFiveActivePlayers;
        }

        void View_Add(String name)
        {
            _players = _players
                .Select(x => x.Player)
                .Concat(new List<Player>() { new Player(name) })
                .Select(x =>
                {
                    var pl = new PlayerViewModel(new PlayerView(), x,_players.Count() >= 5);                    
                    return pl;
                }).ToList();
            SetPlayers(_players);
        }
    }
}
