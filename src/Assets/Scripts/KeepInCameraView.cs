using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInCameraView : MonoBehaviour
{
    private Vector2 screenBounds;
    private float offsetX;
    private float offsetY;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        offsetX = GetComponent<SpriteRenderer>().bounds.extents.x;
        offsetY = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, -screenBounds.x + offsetX, screenBounds.x - offsetX);
        viewPosition.y = Mathf.Clamp(viewPosition.y, -screenBounds.y + offsetY, screenBounds.y - offsetY);
        transform.position = viewPosition;
    }


}
