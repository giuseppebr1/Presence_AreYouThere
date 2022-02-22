using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float sensitivity,speed;
    //private float timeCounter = 0;
    //private float x, z;

    //public float speed=5, width=4, height=7, y=10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(sensitivity, 0, 0) * Time.deltaTime * speed;
        //timeCounter += Time.deltaTime*speed;
        //x = Mathf.Cos(timeCounter)*width;
        //z = Mathf.Sin(timeCounter)*height;

        //transform.position = new Vector3(x, y, z);
    }
}
