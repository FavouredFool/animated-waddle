using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBars : MonoBehaviour
{
    Camera thisCamera;
    public Vector2 resolution = new Vector3(1920f, 1080f);

    private void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.MaximizedWindow);
    }

    /**
    void Update()
    {
        thisCamera = GetComponent<Camera>();
        Vector2 resTarget = resolution;
        Vector2 resViewport = new Vector2(Screen.width, Screen.height);
        Vector2 resNormalized = resTarget / resViewport;
        Vector2 size = resNormalized / Mathf.Max(resNormalized.x, resNormalized.y);
        thisCamera.rect = new Rect(default, size) { center = new Vector2(0.5f, 0.5f) };
    }
    */
}
