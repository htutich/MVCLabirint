using UnityEngine;
using System;
using static UnityEngine.Random;

namespace MVCLabirint
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IUpdatable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();
        public Action WasInteract;

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
            WasInteract?.Invoke();
            Destroy(gameObject);
        }

        #endregion


        #region Methods

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = ColorHSV();
            }
        }

        public void Tick()
        {
        }

        #endregion
    }
}
