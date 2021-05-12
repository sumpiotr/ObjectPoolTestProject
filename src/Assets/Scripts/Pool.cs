using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool 
{
    protected uint size = 0;
    protected GameObject poolObject;
    protected Transform poolParent;

    public Pool(uint size, GameObject poolObject, Transform poolParent = null)
    {
        this.size = size;
        this.poolObject = poolObject;
        this.poolParent = poolParent;

        CreatePool();
    }

    protected virtual void CreatePool() { }

    protected GameObject SpawnObject(Vector3 position, IEnumerable<GameObject> pool)
    {
        foreach (GameObject o in pool)
        {
            if (o.active == false)
            {
                o.transform.position = position;
                o.SetActive(true);
                return o;
            }
        }
        return null;
    }

    public uint GetSize()
    {
        return size;
    }

}
