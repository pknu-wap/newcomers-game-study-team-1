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

        for(uint i = 0; i < 35; i++) {
            
        }
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
                return new Vector2((int)offsetInSide + sideLength/2 - 2*layer + 1,sideLength / 2);
            case 1:
                return new Vector2(sideLength / 2, -(int)offsetInSide + sideLength / 2 - 1);
            case 2:
                return new Vector2(-(int)offsetInSide + sideLength/2 - 1, -(int)sideLength / 2);
            case 3:
                return new Vector2(-sideLength / 2, (int)offsetInSide - sideLength / 2 + 1);
        }

        return new Vector2(0, 0);
    }

    private uint vector2ToChunkIndex(Vector2 pos) {
        uint absX = (uint)Math.Abs(pos.x), absY = (uint)Math.Abs(pos.y);
        uint max, sideLength, startIndex, offsetInLayer;
        if(absX>absY) {
            max = absX;
            startIndex = (uint)Math.Pow(2 * max - 1,2);
            sideLength = 2 * max + 1;
            if(pos.x>=0) {
                if(pos.y==sideLength/2) {
                    offsetInLayer = 2 * max - 1;
                } else {
                    offsetInLayer = (uint)(2 * max + sideLength / 2 - 1 - (int)pos.y);
                }
            } else {
                if(pos.y==-sideLength/2) {
                    offsetInLayer = 6 * max - 1;
                } else {
                    offsetInLayer = (uint)(6 * max + sideLength / 2 - 1 + (int)pos.y);
                }
            }
        } else {
            max = absY;
            startIndex = (uint)Math.Pow(2 * max - 1, 2);
            sideLength = 2 * max + 1;
            if(pos.y>=0) {
                if(pos.x == -sideLength / 2) {
                    offsetInLayer = 8 * max - 1;
                } else {
                    offsetInLayer = (uint)(sideLength/2 - 1 + (int)pos.x);
                }
            } else {
                if(pos.x == sideLength / 2) {
                    offsetInLayer = 4 * max - 1;
                } else {
                    offsetInLayer = (uint)(4 *max + sideLength/2-1 - (int)pos.x);
                }
            }
        }

        return startIndex + offsetInLayer;
    }
}
