using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ragg.io.Views;
using Ragg.io.Models;

namespace Ragg.io.Viewmodels
{
    public class ShellViewModel : BaseViewModel<ShellView>
    {
        public HeaderViewModel Header { get; private set; }
        public GamesViewModel Games { get; private set; }

        private IEnumerable<Player> _players = new List<Player>();

        public ShellViewModel(ShellView view) : base(view) 
        {
            SetHeader(new HeaderViewModel(new HeaderView(), new List<PlayerViewModel>()));
            Games = new GamesViewModel(new GamesView(), new List<Game>(), _players);            
        }

        private void SetHeader(HeaderViewModel header)
        {
            Header = header;
            Header.SetPlayers += x =>
            {
                _players = x.Select(y => y.Player).ToList();
                SetHeader(new HeaderViewModel(new HeaderView(), x.ToList()));
            };
            Header.AddGame += new Action<ITeam, ITeam, int>(Header_AddGame);
            Notify(() => Header);
        }

        void Header_AddGame(ITeam arg1, ITeam arg2, int arg3)
        {
            IGame newGame = new Game(arg1, arg2, arg3, Games.LastGame);
            Games = new GamesViewModel(
                new GamesView(),
                Games.Games.Select(x => x.Game).Concat(new List<IGame>() { newGame }),
                _players);
            Notify(() => Games);
            View.ScrollToBottom();  
        }
    }
}
