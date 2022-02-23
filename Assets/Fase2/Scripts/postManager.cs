using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postManager : MonoBehaviour
{
    public GameObject foto, finale;
    private bool spawned = false;
    public float distance = 20f;

    private Vector3 prova;

    public float movementSpeed = 15;

    public Camera camera;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main;
        foto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawned && Input.GetKey("space"))
        {
            Vector3 cameraForward = camera.transform.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();
            Debug.Log("------ POSIZIONE: " + cameraForward);

            foto.SetActive(true);
            foto.transform.position = transform.position + new Vector3(0,8,0);
            foto.transform.forward = cameraForward;

            prova = foto.transform.position - camera.transform.position;
            prova.y = 0;
            prova.Normalize();

            //finale = GameObject.Find("finale");
            audio.Play();
            spawned = true;
        }
        else if(spawned)
        {
            Debug.Log("foto "+ finale.transform.forward);
            Debug.Log("camera "+ transform.forward);

            //creare un vettore con due punti

            //foto.transform.lo = foto.transform.position - (prova * movementSpeed * Time.deltaTime);

            foto.transform.Translate(-Vector3.forward * movementSpeed * Time.deltaTime);

            //ALTERNATIVA
            /**
             * Far fluttuare tutte le immagini, dopo un tot di tempo una delle immagini si ingrandisce
             * e si va col fade al bianco sulla fase 3
             */


            if (distanzaFinale() < 70 && distanzaFinale() > 68)
                movementSpeed= movementSpeed/4*3;
            Debug.Log("distanza " + distanzaFinale());
            Debug.Log("velocita " + movementSpeed);


            if (distanzaFinale() == 1)
                fade();

            return;

            //OLD CODE
            //if (distanzaFinale() == distance)
            //    GetComponent<MainCamera>().sensitivity /= 2;
            //else if (distanzaFinale() == distance / 1.5)
            //    GetComponent<MainCamera>().sensitivity /= 2;
            //else if (distanzaFinale() == distance / 2)
            //    GetComponent<MainCamera>().sensitivity /= 2;
            //else if (distanzaFinale() == 1)
            //    fade();
        }
    }

    float distanzaFinale()
    {
        // Cambiare e mettere Vector3.Distance(camera, finale)
        return Mathf.Abs(finale.transform.position.z - transform.position.x);
    }

    void fade()
    {
        //todo
        Debug.Log("Finale");
    }
}
