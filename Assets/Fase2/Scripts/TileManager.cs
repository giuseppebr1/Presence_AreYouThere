using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tile;
    public GameObject player;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    public float tileLength;
    private int amnTileOnScreen = 4;
    private bool distruggi = false;
    private Vector3 vz;
    public float time;
    public float lifetime;

    // Use this for initialization
    void Start()
    {
        playerTransform = player.transform;
        //for (int i = 0; i < amnTileOnScreen; i++)
            //SpawnTile();
  
        //tileLength = tile.GetComponent<SkinnedMeshRenderer>().bounds.size.y;
        distruggi = true;
        //tileLength *= 2;
        vz = new Vector3(0f, 0f, tileLength);
        SpawnTile();
        SpawnTile();
        SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (distruggi)
        {
            distruggi = false;
            StartCoroutine(SpawnDelay());
        }
        //if (playerTransform.position.z > (spawnZ - amnTileOnScreen * tileLength))
        //{
        //    if(!distruggi)
        //        SpawnTile();
        //    else
        //        StartCoroutine(SpawnDelay());
        //}
        //Object.Destroy(transform.GetChild(0).gameObject);
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(time);
        SpawnTile();
    }
    IEnumerator DestroyDelay(GameObject go)
    {
        yield return new WaitForSeconds(10);
        distruggi = true;
        DestroyDelay(go);
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tile) as GameObject;
        //go.transform.SetParent(transform);
        go.transform.position += vz;
        vz.z += tileLength;
        Destroy(go, lifetime);
        distruggi = true;
        //if (!distruggi)
        //    Destroy(go, 5);
        //else
        //    Destroy(go, 5);
    }
}