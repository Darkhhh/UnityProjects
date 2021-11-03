using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameObject _endGamePanel;

    [SerializeField] private int _shovelAmount;
    [SerializeField] private int _goldAmount;  
    
    void Awake(){
        SetActiveEndPanel(false, "");
        _uiManager.SetShovelText(_shovelAmount.ToString());
        _uiManager.SetGoldText(_goldAmount.ToString());
    }
    public void DecreaseShovels(){
        _shovelAmount--;
        _uiManager.SetShovelText(_shovelAmount.ToString());
        if(_shovelAmount < 1){
            SetActiveEndPanel(true,"Поражение");
        }
    }
    public void DecreaseGold(){
        _goldAmount--;
        _uiManager.SetGoldText(_goldAmount.ToString());
        if(_goldAmount < 1){
            SetActiveEndPanel(true, "Победа!");
        }
    }
    private void SetActiveEndPanel(bool value, string endPanelText){
        _endGamePanel.SetActive(value);
        _uiManager.SetEndGamePanelText(endPanelText);
    }
}
