using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject firstObstacle;
    [SerializeField] private GameObject secondObstacle;
    [SerializeField] private int _appearenceX = 15;
    private float _currentX;
    [SerializeField] private float _constY = -5.6f;
    private float _firstObsConstY;
    private float _secondObsConstY;
    private float _constZ = 0;
    [SerializeField] private int _disappearenceX = -15;
    void Start()
    {
        _firstObsConstY = firstObstacle.transform.position.y;
        _secondObsConstY = secondObstacle.transform.position.y;

        firstObstacle.transform.position = new Vector3(_appearenceX, _firstObsConstY, _constZ);
        secondObstacle.transform.position = new Vector3(_appearenceX, _secondObsConstY, _constZ);

        _currentX = _appearenceX;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _currentX -= 0.1f;
        firstObstacle.transform.position = new Vector3(_currentX, _firstObsConstY, _constZ);
        secondObstacle.transform.position = new Vector3(_currentX, _secondObsConstY, _constZ);
        if(_currentX < _disappearenceX) gameObject.SetActive(false);
        if(_currentX < _disappearenceX) Destroy(gameObject);
    }
}
