using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ragg.io.Views;
using Ragg.io.Models;
using System.Windows;

namespace Ragg.io.Viewmodels
{
    public class PlayerViewModel : BaseViewModel<PlayerView> 
    {
        public event Action ValidationChanged;

        private bool _chiamata;
        private bool _socio;
        private bool _morto;

        private bool _mortoActive;

        public bool Chiamata
        {
            get { return _chiamata; }
            set { _chiamata = value; Notify(() => Chiamata);  ValidationChanged(); }
        }

        public bool Socio
        {
            get { return _socio; }
            set { _socio = value; Notify(() => Socio); ValidationChanged(); }
        }

        public bool Morto
        {
            get { return _morto; }
            set { _morto = value; Notify(() => Morto); ValidationChanged(); }
        }

        public void Reset()
        {
            Chiamata = false;
            Socio = false;
            Morto = false;
        }

        public Player Player { get; private set; }

        public PlayerViewModel(PlayerView view, Player model, bool mortoActive) : base(view)
        {
            _mortoActive = mortoActive;
            Player = model;
        }

        public Visibility MortoVisibility
        {
            get { return _mortoActive ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}
