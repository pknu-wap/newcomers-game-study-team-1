using UnityEngine;
using System;
using System.Collections.Generic;

public class TileGenerator: MonoBehaviour
{
    public GameObject Player;

    public GameObject[] TilePrefabs;

    public uint Width;
    public uint Height;
    public uint RenderDistance;

    private Vector2 _spawnPos;
    private Dictionary<uint, Chunk> _chunks = new();
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

    private Vector2 chunkIndexToVector2(uint index) {
        uint layer;
        if(index == 0) return new Vector2(0, 0);
        else {
            layer = ((uint)Math.Floor(Math.Sqrt((double)index)) + 1) / 2;
        }

        uint startIndex = (uint) Math.Pow(layer * 2 - 1, 2);
        uint side = (index - startIndex) / (2*layer);
        uint sideLength = 2 * layer + 1;
        uint offsetInSide = (index - startIndex) % (2 * layer);

        switch(side) {
            case 0:
                return new Vector2(offsetInSide + sideLength/2 - 2*layer + 1,sideLength / 2);
            case 1:
                return new Vector2(sideLength / 2, -offsetInSide + sideLength / 2);
            case 2:
                return new Vector2(-offsetInSide - sideLength/2 + 2*layer - 1 , -sideLength / 2);
            case 3:
                return new Vector2(-sideLength / 2, offsetInSide - sideLength / 2);
        }
    }

    private void vector2ToChunkIndex() {

    }
}
