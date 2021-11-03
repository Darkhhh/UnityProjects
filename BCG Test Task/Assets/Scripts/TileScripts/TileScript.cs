using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] private int _defaultDepth;
    [Range(0f,1f)] public float _goldProbability;

    private int _localDepth;
    [SerializeField] private GameObject _goldInglot;
    private InglotScript _goldInglotScript;
    
    private GameObject _manager;
    private GameManager _gameManager;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        Initialization();
    }
    private void Initialization(){
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _goldInglotScript = _goldInglot.GetComponent<InglotScript>();
        _manager = GameObject.FindGameObjectWithTag("Manager");
        _gameManager = _manager.GetComponent<GameManager>();
        _localDepth = _defaultDepth;
        SolveGoldCondition();
    }

    private int _goldLevel;
    private void SolveGoldCondition(){
        bool WillBeGold(float a, float b) => a < b ? true : false;
        if(WillBeGold(Random.Range(0f,1f), _goldProbability)){
            _goldLevel = Random.Range(1, _defaultDepth);
        }
    }

    void OnMouseDown()
    {
        if(_localDepth > 0 && !_goldInglotScript.IsActive()){
            Digging();
        }
        if(_localDepth == 0){
            SetOpacity(0.01f);
        }  
    }
    private void Digging(){
        _localDepth--;
         _gameManager.DecreaseShovels();
        SetOpacity((float)_localDepth/_defaultDepth);
        if(_localDepth == _goldLevel){
            SetGold(true);           
        }
    }

    private void SetGold(bool value){
        _goldInglot.SetActive(value);
        _goldInglotScript.SetGameManager(_gameManager);
    }
    private void SetOpacity(float value){
        _spriteRenderer.color = new Color(1f, 1f, 1f, value);
    }
}
