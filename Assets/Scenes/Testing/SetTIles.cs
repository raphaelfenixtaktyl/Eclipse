using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetTIles : MonoBehaviour
{
    [SerializeField] Tilemap tileMap;
    [SerializeField] Tile tile;
    // Start is called before the first frame update
    void Start()
    {
        tileMap.SetTile(Vector3Int.zero, tile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
