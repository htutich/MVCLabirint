using UnityEngine;


namespace MVCLabirint
{
    public class Trap : InteractiveObject
    {
        #region Fields

        private Material _material;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }


        #endregion


        #region Methods

        protected override void Interaction()
        {
            DisplayBonuses.DisplayTrap();
        }

        #endregion

    }
}
