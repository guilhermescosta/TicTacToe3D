using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) 
        {
            other.transform.position = new Vector3(1,4,1);
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Debug.Log("GOOOL ! " + other.GetComponent<Ball>().playerName);
        }
    }
}
