using UnityEngine;


namespace MVCLabirint
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IUpdatable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();


        #region UnityMethods

        private void Start()
        {
            Action();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        #endregion


        #region Methods

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        public void Tick()
        {
        }

        #endregion
    }
}
