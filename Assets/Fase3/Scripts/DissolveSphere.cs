using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour {

    Material[] materials;
    private bool dissolve = false;
    public bool assolto=false;
    public GameObject player;
    public float distanzaMax=60, d;
    public float distance = 20f;
    public float durataDissolvenza = 1f; // say it takes 25 seconds to complete the activity
    float currentZ = 0;   // the amount of time that has elapsed so far

    private void Start() {

        return;
        materials = GetComponent<Renderer>().materials;
        //player = GameObject.Find("FirstPersonController");
        player = Camera.main.gameObject;

        foreach (Material mat in materials)
        {
            mat.SetFloat("_fade", -1);
        }
    }

    private void Update()
    {
        return;
        if (!dissolve)
        {
            if (distanza(player) <= distance) 
                dissolvenza();
            /*
            else
            {
                foreach (Material mat in materials)
                {
                    mat.SetFloat("_fade", 1f);
                    //Debug.Log("_fade " + mat.GetFloat("_fade"));
                    if (mat.GetFloat("_fade") >= 1f)
                        dissolve = false;
                }
            }
            */

            foreach (Material mat in materials)
            {
                d = distanza(player);
                mat.SetFloat("_InteriorSpread", ((d - 0.1f) / d) + 1f);
            }

            /*
            if (dissolve)
            {
                foreach (Material mat in materials)
                {
                    mat.SetFloat("_fade", 1f);
                    //Debug.Log("_fade " + mat.GetFloat("_fade"));
                    if (mat.GetFloat("_fade") >= 1f)
                        dissolve = false;
                }
            }
            */
        }
    }

    float distanza(GameObject go)
    {
        return Vector3.Distance(go.transform.position, transform.position);
    }

    private void dissolvenza()
    {
        currentZ += Time.deltaTime; // add time each frame
        float percentComplete = currentZ / durataDissolvenza; // value between 0 - 1
        percentComplete = Mathf.Clamp01(percentComplete); // this prevents it exceeding 1
        foreach (Material mat in materials)
            mat.SetFloat("_fade ", percentComplete);
        if (percentComplete >= 1)
            dissolve = true;
    }

    public void assolvenza()
    {
        currentZ += Time.deltaTime; // add time each frame
        float percentComplete = durataDissolvenza / currentZ; // value between 0 - 1
        percentComplete = Mathf.Clamp01(percentComplete); // this prevents it exceeding 0
        foreach (Material mat in materials)
            mat.SetFloat("_fade ", percentComplete);
        if (percentComplete <= 0)
            assolto = true;
    }

    public void setDissolve(bool b){ dissolve = b; }
}