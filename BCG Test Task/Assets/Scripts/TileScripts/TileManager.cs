using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int _tilesInRow;
    void Start()
    {
        CreateTiles();
    }
    private void CreateTiles(){
        float startValue = _tilesInRow / 2 - 0.5f;
        float currentX = -startValue, currentY = startValue;
        for(int i = 0; i < _tilesInRow; i++){
            for(int j = 0; j< _tilesInRow; j++){
                CreateTile(new Vector3(currentX,currentY,0));
                currentX++;
            }
            currentX = -startValue;
            currentY--;
        }
    }
    private void CreateTile(Vector3 position){
        Object spaceShip = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Tile.prefab", typeof(GameObject));
        GameObject clone = Instantiate(spaceShip, position, Quaternion.identity) as GameObject;
    }
}
