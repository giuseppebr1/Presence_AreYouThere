using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSphere : MonoBehaviour
{

    private Material fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<Renderer>().material;
        fade.SetFloat("_Fade",0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
