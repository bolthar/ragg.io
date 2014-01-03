using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ragg.io.Views;

namespace Ragg.io.Viewmodels
{
    public class ScoreViewModel : BaseViewModel<ScoreView>
    {
        private int _score;
        private bool _isLast;
        private bool _isAlternate;

        public ScoreViewModel(ScoreView view, int score, bool isLast, bool isAlternate) : base(view)
        {
            _score = score;
            _isLast = isLast;
            _isAlternate = isAlternate;
            Notify(() => ScoreLabel);
        }

        public string ScoreLabel
        {
            get
            {
                if (_score == 0) return "--";
                if (_score > 0) return "+" + _score;
                return _score.ToString();
            }
        }

        public string FontWeight
        {
            get { return _isLast ? "Bold" : "Normal"; }
        }

        public string BackgroundColor
        {
            get { return _isAlternate ? "#eee" : "#fff"; }
        }

        public string ForegroundColor
        {
            get
            {
                if (_score == 0) return "Black";
                return _score > 0 ? "Blue" : "Red";
            }


        }
    }
}
