using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postManager : MonoBehaviour
{
    public GameObject foto, finale;
    private bool spawned = false;
    public float distance = 400f;

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

            foto.SetActive(true);
            foto.transform.position = transform.position + new Vector3(0,8,0);
            foto.transform.forward = cameraForward;

            //finale = GameObject.Find("finale");
            audio.Play();
            spawned = true;
        }
        else if(spawned)
        {
            //Debug.Log("foto "+ finale.transform.forward);
            //Debug.Log("camera "+ transform.forward);

            foto.transform.Translate(-Vector3.forward * movementSpeed * Time.deltaTime);

            //ALTERNATIVA
            /**
             * Far fluttuare tutte le immagini, dopo un tot di tempo una delle immagini si ingrandisce
             * e si va col fade al bianco sulla fase 3
             */

            //PROVA GIUSEPPE velocità finale
            if(distanzaFinale() < distance && distanzaFinale() > 1)
            {
                movementSpeed = distanzaFinale();
            } else if(distanzaFinale() < 1)
            {
                movementSpeed = 0;
            }

            /*
            if (distanzaFinale() < 70 && distanzaFinale() > 68)
                movementSpeed= movementSpeed/4*3;
            Debug.Log("distanza " + distanzaFinale());
            Debug.Log("velocita " + movementSpeed);
            */


            if (distanzaFinale() < 15)
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
        //return Vector3.Distance(camera.transform.position, finale.transform.position);
        return Mathf.Abs(finale.transform.position.z - transform.position.x);
    }

    void fade()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().fadeIn = true;
        GameObject.Find("shepard").GetComponent<AudioSource>().Stop();
        //GameObject.Find("smslungo").GetComponent<AudioSource>();
    }
}
