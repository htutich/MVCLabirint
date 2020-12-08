using UnityEngine.UI;
using UnityEngine;


namespace MVCLabirint
{
    public class DisplayBonuses
    {
        #region Fields

        private static Text _text;
        private static int _bonusCount;
        private static int _maxCount = 3;

        #endregion


        #region Methods

        public DisplayBonuses()
        {
            _bonusCount = 0;
            _text = Object.FindObjectOfType<Text>();
            _text.text = $"Вы набрали {_bonusCount}";
        }

        public void Display(int val)
        {
            _bonusCount += val;
            _text.text = $"Вы набрали {_bonusCount}";
            if (_bonusCount == _maxCount)
            {
                ServiceLocator.Get<GameOver>().GameEnd();
            }
        }

        public void DisplayTrap()
        {
            _text.text = $"Вы попали в ловушку!";
        }

        public void DisplayDie()
        {
            _text.text = $"Вы умерли!";
            ServiceLocator.Get<GameOver>().GameEnd();
        }

        #endregion
    }
}
