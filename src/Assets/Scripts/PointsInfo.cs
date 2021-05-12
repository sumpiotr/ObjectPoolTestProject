using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsInfo : MonoBehaviour
{

    public static PointsInfo info = null;
    public float points;
    public bool endScene;

    private void Awake()
    {
        if (info != null)
        { 
            Destroy(gameObject);
            return;
        }
        info = this;
        DontDestroyOnLoad(this);
        endScene = false;
    }

    void Start()
    {
        
    }


}
