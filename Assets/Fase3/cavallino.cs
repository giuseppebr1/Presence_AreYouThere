using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavallino : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<Renderer>().material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
