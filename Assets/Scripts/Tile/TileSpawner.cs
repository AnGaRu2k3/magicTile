using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData
{
    public int typeTile; // 1->short, 2->long
    public float timeSpawn; 
    public int spawnPlace; // from 0 -> 3
}

public class TileSpawner : MonoBehaviour
{
    public List<TileData> tileSpawnList = new List<TileData>(); // list tile
    public Transform[] spawnPoints; // 4 spawn
    public TileObjectPool shortTilePool;
    public TileObjectPool longTilePool;

    private void Start()
    {
        StartCoroutine(SpawnTiles());
    }

    private IEnumerator SpawnTiles()
    {
        float startTime = Time.time;

        foreach (var tileData in tileSpawnList)
        {
            float waitTime = tileData.timeSpawn - (Time.time - startTime);
            if (waitTime > 0)
                yield return new WaitForSeconds(waitTime);


            GameObject tile;
            if (tileData.typeTile == 1) tile = shortTilePool.GetTile();
            else tile = longTilePool.GetTile();
            tile.transform.position = spawnPoints[tileData.spawnPlace].position;
        }
    }
}
