using UnityEngine;
using UnityEngine.SceneManagement;


namespace MVCLabirint
{
    public class GameOver
    {
        #region Fields

        private GameObject _overUI;

        #endregion


        #region Methods

        public GameOver(GameObject gameObject)
        {
            Time.timeScale = 1.0f;
            _overUI = gameObject;
        }

        public void GameEnd()
        {
            Time.timeScale = 0.0f;
            _overUI.SetActive(true);
        }

        #endregion
    }
}
