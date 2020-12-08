using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace MVCLabirint
{
    public class GameManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Vector3 _playerCamera;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _gameOverUI;
        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();
        private InteractiveObject[] _interactiveObjects;

        #endregion


        #region UnityMethods

        private void Start()
        {
            GameObject player = null;

            try
            {
                player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            }
            catch (UnassignedReferenceException)
            {
                string objName = String.Empty;
                if (_playerPrefab == null)
                { 
                    objName = "'Player Prefab'";
                }
                else if (_playerSpawnPoint == null)
                { 
                    objName = "'Start Point'";
                }

                throw new UnassignedReferenceException("Отсутствует объект " + objName + " в GameManager");
            }

            var playerView = player?.GetComponent<PlayerView>();
            _updatables.Add(playerView);
            _fixedUpdatables.Add(playerView);
            _updatables.Add(new CameraController(player.transform, _playerCamera));

            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject != null)
                {
                    interactiveObject.WasInteract += playerView.ChangeColor;
                    _updatables.Add(interactiveObject);
                }
            }

            GameOver gameOver = new GameOver(_gameOverUI);
            ServiceLocator.Set(gameOver);

            new ButtonReloadView(_gameOverUI.GetComponentInChildren<Button>());
        }

        private void Update()
        {
            foreach (var updatable in _updatables)
            {
                updatable?.Tick();
            }
        }

        private void FixedUpdate()
        {
            foreach (var fixedUpdateble in _fixedUpdatables)
            {
                fixedUpdateble?.FixedTick();
            }
        }

        #endregion
    }
}
