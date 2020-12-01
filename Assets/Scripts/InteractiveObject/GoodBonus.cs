using UnityEngine;


namespace MVCLabirint
{
    public class GoodBonus : InteractiveObject
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
            PlayerModel model = new PlayerModel();
            model.Speed = 1;
            PlayerAdapt.Fit(model);
            DisplayBonuses.Display(1);
        }

        #endregion
    }
}
