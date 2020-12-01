using UnityEngine.UI;
using UnityEngine;


namespace MVCLabirint
{
    public static class DisplayBonuses
    {
        #region Fields

        private static Text _text;
        private static int _bonusCount = 0;

        #endregion


        #region Methods

        public static void Initialize()
        {
            _text = Object.FindObjectOfType<Text>();
            _text.text = $"Вы набрали {_bonusCount}";
        }

        public static void Display(int value)
        {
            _bonusCount += value;
            _text.text = $"Вы набрали {_bonusCount}";
        }

        public static void DisplayTrap()
        {
            _text.text = $"Вы попали в ловушку!";
        }

        public static void DisplayDie()
        {
            _text.text = $"Вы умерли!";
        }

        #endregion
    }
}
