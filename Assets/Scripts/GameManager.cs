﻿using System.Collections.Generic;
using UnityEngine;


namespace MVCLabirint
{
    public class GameManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Vector3 _playerCamera;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerPrefab;
        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();

        #endregion


        #region UnityMethods

        private void Start()
        {
            var player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            var playerView = player.GetComponent<PlayerView>();
            _updatables.Add(playerView);
            _fixedUpdatables.Add(playerView);
            _updatables.Add(new CameraController(player.transform, _playerCamera));
        }

        private void Update()
        {
            foreach (var updatable in _updatables)
            {
                updatable.Tick();
            }
        }

        private void FixedUpdate()
        {
            foreach (var fixedUpdateble in _fixedUpdatables)
            {
                fixedUpdateble.FixedTick();
            }
        }

        #endregion
    }
}