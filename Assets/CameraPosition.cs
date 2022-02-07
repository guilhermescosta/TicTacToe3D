using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    Camera _camera;
    public GameObject cameraCenter;
    

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();


        if (_camera != null)
        {
            // configure and make camera a child of player with 3rd person offset
            _camera.orthographic = false;
            _camera.transform.SetParent(transform);
            _camera.transform.localPosition = new Vector3(0f, 0.5f, 1f);
            _camera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            cameraCenter.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
