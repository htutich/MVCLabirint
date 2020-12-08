using UnityEngine.SceneManagement;


namespace MVCLabirint
{
    public class ButtonReloadController
    {
        #region Methods

        public void Reload()
        {
            ServiceLocator.Destroy();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        #endregion
    }

}
