using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : MonoBehaviour
{
   public PointSys pointSys;

    [SerializeField] private Pooler bulletPool;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length - 1);
            GameObject g = bulletPool.GetObject();
            g.transform.position = spawnSpots[randPos].position;
            g.transform.rotation = spawnSpots[randPos].rotation;
            g.SetActive(true);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else 
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }  
}
