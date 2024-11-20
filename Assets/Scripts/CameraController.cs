using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; } = null;
    [SerializeField] private new Camera camera; 
    private void Awake()
    {
        if(Instance is null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    public void ChangeFOV(float value)
    {
        if (value > 5)
            camera.orthographicSize = 10;
        else camera.orthographicSize = 5; 
    }
}
