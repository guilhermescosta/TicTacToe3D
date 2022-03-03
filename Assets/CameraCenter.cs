using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraCenter : MonoBehaviour
{
    public bool onGrid;
    public GameController _gameController;
    public GameObject gridPosition;
    public GameObject _camera;
    // Start is called before the first frame update
    
    Camera mainCam;

    

    void Awake()
    {
        mainCam = Camera.main;
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Start() 
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       /*
            if (onGrid && Input.GetMouseButtonDown(0) && gridPosition.tag!="UsedGrid" )
        {
            if (_gameController.actualPlayer == 1)
            {
                gridPosition.GetComponent<MeshRenderer>().material = _gameController.crossMaterial;
                _gameController.gridArray[Convert.ToInt32(gridPosition.name)] = 1;
                _gameController.CheckGame();
                gridPosition.tag = "UsedGrid";
                _gameController.actualPlayer = 2;
                 
            }
            else if (_gameController.actualPlayer == 2)
            {
                gridPosition.GetComponent<MeshRenderer>().material = _gameController.circleMaterial;
                _gameController.gridArray[Convert.ToInt32(gridPosition.name)] = 2;
                _gameController.CheckGame();
                gridPosition.tag = "UsedGrid";
                _gameController.actualPlayer = 1;
                
            }
        }

        */
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Grid"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.blue;
            onGrid = true;
            gridPosition = other.gameObject;
            // Debug.Log(other.GetComponent<MeshRenderer>().material.color);
        }
        else if (other.CompareTag("UsedGrid"))
            Debug.Log("posicao utilizada");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grid"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.white;
            onGrid = false;
        }

    }
}
