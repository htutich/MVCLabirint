using UnityEngine;


namespace MVCLabirint
{
    public class PlayerController : IUpdatable, IFixedUpdatable
    {
        #region Fields

        public PlayerModel _model;

        private Rigidbody _rigidbody;
        private Vector3 _movement;

        #endregion

        #region Methods

        public PlayerController(float speed, float health, float forceJump, GameObject player)
        {
            _model = new PlayerModel();
            _model.Speed = speed;
            _model.HealthPoints = health;
            _model.ForceJump = forceJump;
            _rigidbody = player.GetComponent<Rigidbody>();
            PlayerAdapt.Initialize(this);

            DisplayBonuses displayBonuses = new DisplayBonuses();
            ServiceLocator.Set(displayBonuses);

        }

        public void Tick()
        {
            _movement.x = Input.GetAxis("Horizontal");
            _movement.z = Input.GetAxis("Vertical");
        }

        public void FixedTick()
        {
            _movement = _movement * _model.Speed;
            _movement.y = _rigidbody.velocity.y;
            _rigidbody.velocity = _movement;
        }

        #endregion
    }
}
