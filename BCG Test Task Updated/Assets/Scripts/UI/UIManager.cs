using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField] private GameObject mainCanvas;
        [SerializeField] private GameObject endgameCanvas;

        [SerializeField] private Text endgameText;
        [SerializeField] private Text shovelsAmountText;
        [SerializeField] private Text goldAmountText;

        #endregion


        #region Event Functions

        private void Awake()
        {
            mainCanvas.SetActive(true);
            endgameCanvas.SetActive(false);
        }

        #endregion
        
        
        #region Public Methods

        public void SetShovelsAmount(int shovelsAmount, int defaultShovelsAmount)
        {
            var text = "Shovels: " + shovelsAmount + "/" + defaultShovelsAmount;
            shovelsAmountText.text = text;
        }

        public void SetGoldAmount(int goldAmount, int winGoldAmount)
        {
            var text = "Gold: " + goldAmount + "/" + winGoldAmount;
            goldAmountText.text = text;
        }

        public void ActivateEndGamePanel(string message)
        {
            mainCanvas.SetActive(false);
            endgameCanvas.SetActive(true);
            endgameText.text = message;
        }

        #endregion


        #region Button Handlers

        public void RestartButtonHandler()
        {
            GameManager.Instance.RestartGame();
        }

        #endregion
    }
}
