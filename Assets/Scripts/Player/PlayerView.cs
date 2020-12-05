using UnityEngine;
using static UnityEngine.Random;


namespace MVCLabirint
{
    public class PlayerView : MonoBehaviour, IUpdatable, IFixedUpdatable
    {
        #region Fields

        [SerializeField] private float _speed = 0.3f;
        [SerializeField] private float _health = 100.0f;
        [SerializeField] private float _forceJump = 2.0f;
        private PlayerController _controller;
        private Animator _animator;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _controller = new PlayerController(_speed, _health, _forceJump, gameObject);
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion


        #region Methods

        public void Tick()
        {
            _controller.Tick();
        }

        public void FixedTick()
        {
            _controller.FixedTick();
        }

        public void ChangeColor()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = ColorHSV();
            }
        }


        #endregion
    }
}
