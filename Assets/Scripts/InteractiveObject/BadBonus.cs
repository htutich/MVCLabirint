using UnityEngine;


namespace MVCLabirint
{
    public class BadBonus : InteractiveObject
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
            ServiceLocator.Get<DisplayBonuses>().Display(-1);

        }

        #endregion

    }
}
