using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Instance

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<GameManager>();
            if (_instance == null)
            {
                _instance = new GameObject(
                    "Spawned GameplayManager",
                    typeof(GameManager)).GetComponent<GameManager>();
            }
            return _instance;
        }
        private set => _instance = value;
    }

    #endregion


    #region Serialize Fields

    [SerializeField] private int defaultShovelsAmount;
    [SerializeField] private int winGoldAmount;
    [SerializeField] private UIManager _uiManager;

    #endregion


    #region Private Values

    private int _shovelsAmount;

    private int _goldAmount;

    #endregion


    #region Event Functions

    private void Start()
    {
        if(defaultShovelsAmount < 1 || winGoldAmount < 1) Debug.LogError("Incorrect values for shovels or gold");
        _shovelsAmount = defaultShovelsAmount;
        _goldAmount = 0;
        _uiManager.SetShovelsAmount(_shovelsAmount, defaultShovelsAmount);
        _uiManager.SetGoldAmount(_goldAmount, winGoldAmount);
    }

    #endregion


    #region Public Methods

    public void DecreaseShovel()
    {
        _shovelsAmount--;
        if(_shovelsAmount < 1) _uiManager.ActivateEndGamePanel("Sorry, you're out of shovels...");
        _uiManager.SetShovelsAmount(_shovelsAmount, defaultShovelsAmount);
    }

    public void IncreaseGold()
    {
        _goldAmount++;
        if(_goldAmount >= winGoldAmount) _uiManager.ActivateEndGamePanel("Nice, you found all gold!");
        _uiManager.SetGoldAmount(_goldAmount, winGoldAmount);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    #endregion
    
}
