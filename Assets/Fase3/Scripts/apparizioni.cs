using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apparizioni : MonoBehaviour
{
    public float frequenza = 2f;
    private sparizioni sp;
    private int i = 0;
    private float L;
    public float primaAssolvenza=0.2f;
    public float altreAssolvenze = 2f;
    void Start()
    {
        
        
    }

    public void startGuidato()
    {
        sp= GetComponent<sparizioni>();
        L = sp.pg.Count;
        InvokeRepeating("assolve", primaAssolvenza, altreAssolvenze);
        if (i >= L)
            return;
    }

    void assolve()
    {
        if (i < L)
        {
            //Debug.Log("apparizioni ");
            sp.assolve(i++);
        }
    }

}
