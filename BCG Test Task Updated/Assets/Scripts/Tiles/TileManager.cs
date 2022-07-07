using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tiles
{
    public class TileManager : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField][Range(1,10)] private int tilesInRow;

        #endregion


        #region Private Values

        private List<TileScript> _tiles;

        #endregion


        #region Event Functions

        void Start()
        {
            CreateTiles();
        }
        
        #endregion


        #region Private Methods

        private void CreateTiles()
        {
            _tiles = new List<TileScript>();
            var startValue = (float)tilesInRow / 2 - 0.5f * ((tilesInRow + 1) % 2);
            float currentX = -startValue, currentY = startValue;
            for(var i = 0; i < tilesInRow; i++){
                for(var j = 0; j< tilesInRow; j++){
                    CreateTile(new Vector3(currentX,currentY,0));
                    currentX++;
                }
                currentX = -startValue;
                currentY--;
            }
        }
        
        private void CreateTile(Vector3 position){
            var tile = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Tile.prefab", typeof(GameObject));
            var clone = Instantiate(tile, position, Quaternion.identity) as GameObject;
            if (clone == null) return;
            clone.transform.SetParent(transform);
            _tiles.Add(clone.GetComponent<TileScript>());
            _tiles[_tiles.Count - 1].OnTileClick += HandleTileEvents;
        }
        
        private void HandleTileEvents(TileScript.TileEvent tileEvent)
        {
            switch (tileEvent)
            {
                case TileScript.TileEvent.DecreaseShovel:
                    GameManager.Instance.DecreaseShovel();
                    break;
                case TileScript.TileEvent.IncreaseGold:
                    GameManager.Instance.IncreaseGold();
                    break;
            }
        }

        #endregion
    }
}
