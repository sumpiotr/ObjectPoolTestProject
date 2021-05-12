using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPool : Pool
{
    private List<GameObject> pool;

    public DynamicPool(uint size, GameObject poolObject, Transform poolParent = null) : base(size, poolObject, poolParent)
    {
    }

    protected override void CreatePool()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            pool.Add(poolParent == null ? Object.Instantiate(poolObject) : Object.Instantiate(poolObject, poolParent));
            pool[i].SetActive(false);
        }
    }

    public GameObject SpawnObject(Vector3 position)
    {
        return SpawnObject(position, pool);
    }

    public void AddObjects(uint count) 
    {
        size += count;
        for (int i = 0; i < count; i++)
        {
            pool.Add(poolParent == null ? Object.Instantiate(poolObject) : Object.Instantiate(poolObject, poolParent));
            pool[pool.Count - 1].SetActive(false);
        }
    }
}
