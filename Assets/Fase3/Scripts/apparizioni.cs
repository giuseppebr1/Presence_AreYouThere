using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apparizioni : MonoBehaviour
{
    public float frequenza = 5f;
    private sparizioni sp;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("apparizioni", 0.5f, frequenza);
        sp = GetComponent<sparizioni>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
