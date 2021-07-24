using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerScore;
    [SerializeField] private float _scoreTimeInterval = 1.5f;
    [SerializeField] private int _scoreIncreaseValue = 10;


    void Start()
    {
        _playerScore = 0;
        StartCoroutine("ScoreIncreasing");
    }


    void Update()
    {
    }


    void OnGUI(){
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + _playerScore.ToString());
    }

    public void BirdCollision(){
        Time.timeScale = 0;
    }
    
    IEnumerator ScoreIncreasing(){
        yield return new WaitForSeconds(_scoreTimeInterval * 2);
        for(;;){
            yield return new WaitForSeconds(_scoreTimeInterval);
            _playerScore+=_scoreIncreaseValue;
        }
    }
}
