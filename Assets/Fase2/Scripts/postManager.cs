using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postManager : MonoBehaviour
{
    public GameObject foto, finale;
    private bool spawned = false;
    public float distance = 20f;

    public float movementSpeed = 10;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
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
            foto.transform.position = transform.position;
            foto.transform.forward = cameraForward;

            //finale = GameObject.Find("finale");
            spawned = true;
        }
        else if(spawned)
        {
            //Debug.Log("foto "+ finale.transform.position.z);
            //Debug.Log("camera "+ transform.position.x);

            foto.transform.Translate(foto.transform.right * movementSpeed * Time.deltaTime);

            if (distanzaFinale() == 1)
                fade();

            return;

            //OLD CODE
            if (distanzaFinale() == distance)
                GetComponent<MainCamera>().sensitivity /= 2;
            else if (distanzaFinale() == distance / 1.5)
                GetComponent<MainCamera>().sensitivity /= 2;
            else if (distanzaFinale() == distance / 2)
                GetComponent<MainCamera>().sensitivity /= 2;
            else if (distanzaFinale() == 1)
                fade();
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
