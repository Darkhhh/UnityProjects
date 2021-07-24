using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject firstObstacle;
    private Vector3 firstObstaclePosition;
    [SerializeField] private GameObject secondObstacle;
    private Vector3 secondObstaclePosition;
    [SerializeField] private GameObject thirdObstacle;
    private Vector3 thirdObstaclePosition;
    [SerializeField] private GameObject fourthObstacle;
    private Vector3 fourthObstaclePosition;
    

    private float _spawningTime = 1.5f;
    void Start()
    {
        firstObstacle.SetActive(false);
        firstObstaclePosition = firstObstacle.transform.position;
        secondObstacle.SetActive(false);
        secondObstaclePosition = secondObstacle.transform.position;
        thirdObstacle.SetActive(false);
        thirdObstaclePosition = thirdObstacle.transform.position;
        fourthObstacle.SetActive(false);
        fourthObstaclePosition = fourthObstacle.transform.position;
        StartCoroutine("ObstacleSpawning");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        
    }
    IEnumerator ObstacleSpawning(){
        for(;;){
            yield return new WaitForSeconds(_spawningTime);
            int randomObstacle = Random.Range(1, 4);
            if(randomObstacle == 1){
                var clone = Instantiate(firstObstacle, firstObstaclePosition, Quaternion.identity) as GameObject;
                clone.SetActive(true);
            }
            if(randomObstacle == 2){
                var clone = Instantiate(secondObstacle, secondObstaclePosition, Quaternion.identity) as GameObject;
                clone.SetActive(true);
            }
            if(randomObstacle == 3){
                var clone = Instantiate(thirdObstacle, thirdObstaclePosition, Quaternion.identity) as GameObject;
                clone.SetActive(true);
            }
            if(randomObstacle == 4){
                var clone = Instantiate(fourthObstacle, fourthObstaclePosition, Quaternion.identity) as GameObject;
                clone.SetActive(true);
            }
        }       
    }
}
