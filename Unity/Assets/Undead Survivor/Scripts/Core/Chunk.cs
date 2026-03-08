using UnityEngine;
using System.Collections.Generic;

public class Chunk
{
    private static GameObject[] _tilePrefabs;

    private const uint TILE_SIZE_X = 1;
    private const uint TILE_SIZE_Y = 1;

    private Vector2 _origin;
    private uint _width;
    private uint _height;

    private GameObject[,] _tiles;

    public static void SetTilePrefabs(GameObject[] prefabs) {
        _tilePrefabs = new GameObject[prefabs.Length];
        
        for(uint i=0; i<prefabs.Length; i++) {
            _tilePrefabs[i] = prefabs[i];
        }
    }

    public Chunk(Vector2 origin, uint w, uint h) {
        _origin = new Vector2(origin.x, origin.y);
        _width = w;
        _height = h;

        _tiles = new GameObject[h, w];
    }

    public void Generate(bool visible = true) {
        Debug.Log(_width);
        Vector2 offset = new(0, 0);
        for(int i=0; i<_height; i++) {
            offset.y = _height/2 - i;
            for(int j=0; j<_width; j++) {
                int tileIndex = Random.Range(0, _tilePrefabs.Length);

                offset.x = _width / 2 - j;
                _tiles[i, j] = GameObject.Instantiate(_tilePrefabs[tileIndex], _origin + offset, Quaternion.identity);
            }
        }

        if(visible) {
            SetActive(true);
        }
    }

    public void SetActive(bool set) {
        foreach(GameObject tile in _tiles) {
            tile.SetActive(set);
        }
    }

}
