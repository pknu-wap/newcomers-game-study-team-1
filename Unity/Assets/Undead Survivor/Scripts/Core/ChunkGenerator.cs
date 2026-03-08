using UnityEngine;
using System;
using System.Collections.Generic;

public class ChunkGenerator: MonoBehaviour
{
    public GameObject Player;

    public GameObject[] TilePrefabs;

    public uint Width;
    public uint Height;
    public uint RenderDistance;

    private Vector2 _spawnPos;
    private Dictionary<uint, Chunk> _chunks = new();
    private uint _currentChunkIndex = 0;

    private Vector2 _previousChunkOffset = new Vector2(0,0);

    void Awake() {
        Chunk.SetTilePrefabs(TilePrefabs);

        if(Width % 2 == 0) Width++;
        if(Height % 2 == 0) Height++;

        _spawnPos = new Vector2(0,0);
        /* DON'T CHANGE THIS VALUE until refactoring the way to find the offset of the chunk
         * where the player is.
         */

        uint count = (uint)Math.Pow(2 * RenderDistance + 1, 2);
        for(uint i = 0; i < count; i++) {
            Chunk chunk = new(ChunkIndexToChunkPos(i), Width, Height);
            chunk.Generate();
            _chunks.Add(i, chunk);
        }
    }

    void LateUpdate() {
        // Find The index of the chunk where the player is in.
        Vector2 currentChunkOffset = PlayerPosToChunkOffset(Player.transform.position);
        if(currentChunkOffset!=_previousChunkOffset) {
            Vector2 offset = new(0, 0);
            uint chunkIndex = 0;
            for(int i=(int)-RenderDistance; i<=RenderDistance; i++) {
                offset.y = i;
                for(int j=(int)-RenderDistance; j<=RenderDistance; j++) {
                    offset.x = j;
                    chunkIndex = ChunkOffsetToChunkIndex(offset + currentChunkOffset);
                    if(!_chunks.ContainsKey(chunkIndex)) {
                        Chunk chunk = new(ChunkIndexToChunkPos(chunkIndex), Width, Height);
                        chunk.Generate();
                        _chunks.Add(chunkIndex, chunk);
                    }
                }
            }
            _previousChunkOffset = currentChunkOffset;
        }
    }

    public Vector2 PlayerPosToChunkOffset(Vector2 pos) {
        int xOffset = (int)Math.Round(pos.x / Width);
        int yOffset = (int)Math.Round(pos.y / Height);
        return new Vector2(xOffset, yOffset);
    }

    public Vector2 ChunkIndexToChunkPos(uint index) {
        Vector2 offset = ChunkIndexToChunkOffset(index);
        return _spawnPos + offset * new Vector2(Width, Height);
    }

    public Vector2 ChunkIndexToChunkOffset(uint index) {
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

    public uint ChunkOffsetToChunkIndex(Vector2 pos) {
        if(pos.x==0 && pos.y==0) {
            return 0;
        }

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
