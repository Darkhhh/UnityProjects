using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _shovelText;
    [SerializeField] private Text _goldText;
    [SerializeField] private Text _endPanelText;

    public void OnRestartButtonClick(){
        SceneManager.LoadScene("SampleScene");
    }
    public void SetShovelText(string value){
        _shovelText.text = value;
    }
    public void SetGoldText(string value){
        _goldText.text = value;
    }
    public void SetEndGamePanelText(string value){
        _endPanelText.text = value;
    }
}
