using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSizePool : Pool
{
    private GameObject[] pool;

    public FixedSizePool(uint size, GameObject poolObject, Transform poolParent = null) : base(size, poolObject, poolParent)
    {
    }

    protected override void CreatePool() 
    {
        pool = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            pool[i] = poolParent == null ? Object.Instantiate(poolObject) : Object.Instantiate(poolObject, poolParent);
            pool[i].SetActive(false);
        }
    }

    public GameObject SpawnObject(Vector3 position) 
    {
        return SpawnObject(position, pool);
    }
}
