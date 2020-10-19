using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private List<TileData> tileDatas;
    
    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)  //go into GrassTileData, go into StoneTileData
        {
            foreach (var tile in tileData.tiles)  //go into grass tile 1, go into grass tile 2
            {
                dataFromTiles.Add(tile, tileData);  //add (grass tile 1, GrassTileData), add (grass tile 2, GrassTileData)
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = tileMap.WorldToCell(worldPos);
            TileBase clickedTile = tileMap.GetTile(gridPos);

            float walkingSpeed = dataFromTiles[clickedTile].walkingSpeed;

            //Debug.Log("GridPos: " + gridPos + "Tile: " + clickedTile);
            Debug.Log("Walking Speed on " + clickedTile + "is: " + walkingSpeed);

        }
    }

    public float GetTileWalkingSpeed(Vector2 worldPos)
    {
        Vector3Int gridPos = tileMap.WorldToCell(worldPos);
        TileBase tile = tileMap.GetTile(gridPos);

        if (tile == null)
            return 1f;

        float walkingSpeed = dataFromTiles[tile].walkingSpeed;

        return walkingSpeed;
    }


}
