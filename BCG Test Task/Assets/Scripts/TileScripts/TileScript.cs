using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] private int _defaultDepth;
    [Range(0f,1f)] public float _goldProbability;

    private int _localDepth;
    [SerializeField] private GameObject _goldInglot;
    private bool _goldInglotOn;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _localDepth = _defaultDepth;
        _goldInglotOn = true;
        SetGold(true);
    }
    void OnMouseDown()
    {
        if(_localDepth > 0){
            _localDepth--;
            SetOpacity((float)_localDepth/_defaultDepth);
        }
        else{
            SetOpacity(0.01f);
            SetGold(false);
        }      
    }


    private void SetGold(bool value){
        _goldInglot.SetActive(value);
    }
    private void SetOpacity(float value){
        _spriteRenderer.color = new Color(1f, 1f, 1f, value);
    }
}
