using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Script : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] private int _jumpForce = 7;
    private GameManager _actionTarget;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _actionTarget = GetComponent<GameManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);        
        }   
    }
    void OnCollisionEnter2D(Collision2D collision){
        _actionTarget.BirdCollision();
    }
}
