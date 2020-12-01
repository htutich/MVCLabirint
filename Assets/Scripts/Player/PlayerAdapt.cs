using UnityEngine;


namespace MVCLabirint
{
    public static class PlayerAdapt
    {
        private static PlayerController _playerController;
        public static void Initialize(PlayerController controller)
        {
            _playerController = controller;
        }

        public static void Fit(PlayerModel model)
        {
            _playerController._model.HealthPoints += model.HealthPoints;
            _playerController._model.Speed += model.Speed;

            if (_playerController._model.HealthPoints <= 0)
            {
                Time.timeScale = 0.0f;
                DisplayBonuses.DisplayDie();
            }
        }
    }

}
