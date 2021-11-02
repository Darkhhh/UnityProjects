using UnityEngine;

public class InglotScript : MonoBehaviour
{
    private bool _isActive;
    void OnEnable(){
        _isActive = true;
    }
    void OnMouseDown(){
        _gameManager.DecreaseGold();
        _isActive = false;
        gameObject.SetActive(false);
    }
    public bool IsActive(){
        return _isActive;
    }

    private GameManager _gameManager;
    public void SetGameManager(GameManager gameManager){
        _gameManager = gameManager;
    }
}
