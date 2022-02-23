using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pavimento : MonoBehaviour
{
    Material mat;
    public float macchie = 125f, oscillazione = 25f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        //mat.SetColor("_EdgeColor", new Color(14f,14f,27f));
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_fade", macchie + Mathf.PingPong(Time.time, oscillazione));
    }
}
