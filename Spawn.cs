using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public PointSys pointSys;
    private bool isCheck = false;
    
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

        Check();
    }  


    private void Check()
    {
        if (pointSys.point % 100 == 0 && pointSys.point !=0 && isCheck == false)
        {
            startTimeBtwSpawns = 2.5f;
            isCheck = true;
        }
        else if(pointSys.point % 200 == 0 && pointSys.point !=0 )
        {
            startTimeBtwSpawns = 1.5f;

        }
    }
}
