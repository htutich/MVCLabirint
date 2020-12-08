using System;
using UnityEngine.UI;


namespace MVCLabirint
{
    public class ButtonReloadView
    {
        #region Fields

        private Button _button;
        private ButtonReloadController _controller;

        #endregion


        #region Methods

        public ButtonReloadView(Button button)
        {
            _controller = new ButtonReloadController();
            button.onClick.AddListener(_controller.Reload);
        }

        #endregion
    }
}
