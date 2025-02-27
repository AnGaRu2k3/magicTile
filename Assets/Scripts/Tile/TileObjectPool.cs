using System.Collections.Generic;
using UnityEngine;

public class TileObjectPool : MonoBehaviour
{
    public Canvas canvas;
    public GameObject tilePrefab;

    public int poolSize = 10; 
    private Queue<GameObject> tilePool = new Queue<GameObject>();


    void Start()
    {
        // init
        for (int i = 0; i < poolSize; i++)
        {
            GameObject tile = Instantiate(tilePrefab, canvas.transform);
            tile.GetComponent<BaseTile>().tilePool = this;
            tile.SetActive(false);
            tilePool.Enqueue(tile);
        }
    }

    public GameObject GetTile()
    {
        if (tilePool.Count > 0)
        {
            GameObject tile = tilePool.Dequeue();
            tile.SetActive(true);
            return tile;
        }
        else
        {
            GameObject newTile = Instantiate(tilePrefab, canvas.transform);
            return newTile;
        }
    }


    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        tilePool.Enqueue(tile);
    }
}
