using UnityEngine;
using System.Collections.Generic;

public class TileGenerator: MonoBehaviour
{
    public GameObject Player;

    public GameObject[] TilePrefabs;

    public uint Width;
    public uint Height;
    public uint RenderDistance;

    private Vector2 _spawnPos;
    private Dictionary<uint, Chunk> _chunks;
    private uint _currentChunkIndex = 0;

    void Awake() {
        Chunk.SetTilePrefabs(TilePrefabs);

        if(Width % 2 == 0) Width++;
        if(Height % 2 == 0) Height++;

        _spawnPos = Player.transform.position;

        Chunk spawnChunk = new(_spawnPos, Width, Height);
        spawnChunk.Generate();
    }

    void Update() {
        
    }
}
