using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ragg.io.Views;

namespace Ragg.io.Viewmodels
{
    public class ControlsViewModel : BaseViewModel<ControlsView>
    {
        public event Action<int, bool> AddGame;

        private bool _isStateValid;
        public bool IsStateValid
        {
            get { return _isStateValid; }
            set
            {
                _isStateValid = value;
                Notify(() => IsStateValid);
            }
        }

        private int _multiplier;
        public int Multiplier
        {
            get { return _multiplier; }
            set
            {
                _multiplier = value;
                Notify(() => x1Toggled);
                Notify(() => x2Toggled);
                Notify(() => x3Toggled);
            }
        }

        public bool x1Toggled { get { return Multiplier == 1; } }
        public bool x2Toggled { get { return Multiplier == 2; } }
        public bool x3Toggled { get { return Multiplier == 3; } }

        public ControlsViewModel(ControlsView view, bool isStateValid) : base(view) 
        {
            View.ChangeMultiplier += new Action<int>(View_ChangeMultiplier);
            View.AddGame += new Action<bool>(View_AddGame);
            IsStateValid = isStateValid;
            Multiplier = 1;
        }

        void View_AddGame(bool hasTeamWon)
        {
            AddGame(Multiplier, hasTeamWon);          
        }

        void View_ChangeMultiplier(int obj)
        {
            Multiplier = obj;
        }

    }
}
