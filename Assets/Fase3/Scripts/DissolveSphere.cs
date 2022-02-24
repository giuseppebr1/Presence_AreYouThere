using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour {

    Material[] materials;
    public bool assolvi = false, assolto = false, dissolto=false, dissolvi = false;
    public GameObject player;
    private float d;
    private sparizioni sp;
    private float currentZ = 0;   // the amount of time that has elapsed so far
    private AudioSource[] sounds;
    private bool suonino = false;
    private void Start() {
        sounds = new AudioSource[2];
        materials = GetComponent<Renderer>().materials;
        player = Camera.main.gameObject;
        //player = GameObject.Find("OVRCameraRig");
        //player = GameObject.Find("Camera"); //debug
        sp = player.GetComponent<sparizioni>();
        if (GetComponent<AudioSource>())
        {
            sounds = GetComponents<AudioSource>();
            suonino = true;
            sounds[2].Stop();
        }


        foreach (Material mat in materials)
        {
            mat.SetFloat("_fade", 0);
           // mat.SetFloat("_FresnelPower", 10f);
            //mat.SetFloat("_InteriorSpread", -10f);
        }
    }

    private float percent;
    private void Update()
    {
        if (!assolto)
        {
            if (assolvi)
            {
                foreach (Material mat in materials)
                {
                    //Debug.Log("Sono nella situazione");
                    if (suonino)
                        sounds[0].Play();
                    percent = Mathf.MoveTowards(percent, 255, sp.velocitaDissolvenza * Time.deltaTime);
                    mat.SetFloat("_fade", percent);

                    if (percent >= 255f)
                    {
                        if (suonino)
                        {
                            sounds[0].Stop();
                            sounds[1].Play();
                        }
                        assolto = true;
                    }
                }
            }
        }
        else if (dissolvi)
        {
            if (suonino)
                sounds[2].Play();
            foreach (Material mat in materials)
            {
                percent = Mathf.MoveTowards(percent, 0, (sp.velocitaDissolvenza + 50f) * Time.deltaTime);
                mat.SetFloat("_fade", percent);

                if (suonino)
                {
                    sounds[0].Stop();
                    sounds[1].Stop();
                    sounds[2].Stop();
                }
                if (percent <= 0f)
                {
                    assolto = true;
                    dissolto = true;
                }
            }
        }
        else
            if (distanza(player) < sp.distance)
            dissolvi = true;
    }

    float distanza(GameObject go)
    {
        return Vector3.Distance(go.transform.position, transform.position);
    }


    //if (assolto && dissolve)
    //{
    //    if (distanza(player) <= sp.distance) 
    //        dissolvenza();
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

    //foreach (Material mat in materials)
    //{
    //    d = distanza(player);
    //    mat.SetFloat("_InteriorSpread", (Mathf.Abs(sp.distanzaMax/d) + 0.2f));
    //}

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
    //}



    public void dissolvenza()
    {
        //currentZ += Time.deltaTime; // add time each frame
        //float percentComplete = currentZ / sp.velocitaDissolvenza; // value between 0 - 1
        //percentComplete = Mathf.Clamp01(percentComplete); // this prevents it exceeding 1
        //foreach (Material mat in materials)
        //    mat.SetFloat("_fade", percentComplete);
        //if (percentComplete >= 1)
        //    dissolve = true;
    }

    public void assolvenza()
    {/*
        float currentTime = 0, percent = 0;
        while (percent<0.999f)
        {
            foreach (Material mat in materials)
            {
                //percent = (currentTime / (sp.velocitaDissolvenza*2f));
                percent=Mathf.MoveTowards(percent, 1, sp.velocitaDissolvenza* Time.deltaTime);
                Debug.Log("percent " + percent);
                mat.SetFloat("_fade", percent);
            }
            currentTime += Time.deltaTime;
        }
        assolto = true;*/


        //StartCoroutine(Ass());
        //currentZ += Time.deltaTime; // add time each frame
        //float percentComplete = sp.velocitaDissolvenza / currentZ; // value between 0 - 1
        //percentComplete = Mathf.Clamp01(percentComplete); // this prevents it exceeding 0
        //foreach (Material mat in materials)
        //    mat.SetFloat("_fade ", percentComplete);
        //if (percentComplete <= 0)
        //    assolto = true;
        //foreach (Material mat in materials)
        //    mat.SetFloat("_fade", 1f);
        //assolto = true;
    }

        //public void setDissolve(bool b){ dissolve = b; }
    }