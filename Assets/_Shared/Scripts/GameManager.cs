using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int state = 0;
    public List<GameObject> sequenza;
    public GameObject visore;
    //private Material fade;
    public Image fade;
    public float velocitaFade = 150f;
    private Vector3 origin;
    float percent = 0f;
    public bool next = false;
    public bool fadeIn = false, fadeOut = false;
   

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject s in sequenza)
            s.SetActive(false);
        origin = new Vector3(0f, 0f, 0f);
        //fade = GameObject.Find("FadeCanva").GetComponent<Renderer>().material;
        fade = GameObject.Find("FadeCanva").GetComponent<Image>();
        //fade.SetColor("_Color", new Color(255f, 255f, 255f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn) //debug
        {
            //nextState();
            percent = Mathf.MoveTowards(percent, 1, velocitaFade * Time.deltaTime);
            //fade.SetFloat("_fade", percent);
            //Debug.Log("AAAAAAA");
            fade.color = new Color(255,255,255,percent);
            Debug.Log("PERCENT "+ percent);
            if (percent >= 1f)
            {
                fadeIn = false;
                visore.transform.position = new Vector3(0f, 0.5f, 0f);
                nextScene();
                Debug.Log("Aaaaaaaaaaaaaaaaaaaaaaaaaaa");
            }
        }
        if (fadeOut) //debug
        {
            //nextState();
            percent = Mathf.MoveTowards(percent, 1, velocitaFade * Time.deltaTime);
            fade.color = new Color(255, 255, 255, (percent-1)*(-1));
            Debug.Log("PAAAAAAQ " + fade.color.a);
            //fade.SetFloat("_fade", percent);
            if (fade.color.a <= 0)
            {
                fadeOut = false;
            }
        }
    }
    void nextScene()
    {
        sequenza[state].SetActive(false);
        Debug.Log("Switchone");
        switch (state)
        {
            case 0: //2->3 reticolo-vr
                state++;
                sequenza[state].SetActive(true);
                percent = 0f;
                fadeOut = true;
                break;
            case 1://3->4 verso pallagiorgia
                state++;
                sequenza[state].SetActive(true);
                percent = 0f;
                fadeOut = true;
                GameObject.Find("360VideoView").GetComponent<AudioSource>().Play(0);
                StartCoroutine(stoppaRingtone());
                break;
            case 2://3->4 tra le due pallex
                state++;
                sequenza[state].SetActive(true);
                percent = 0f;
                fadeOut = true;
                break;
        }
    }

    IEnumerator stoppaRingtone()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("360VideoView").GetComponent<AudioSource>().Stop();
    }

    //void fadeIn()
    //{
    //    Color fadeColor= fade.GetColor("_Color");
    //    percent = 0f;
    //    while (percent < 255f)
    //    {
    //        percent = Mathf.MoveTowards(percent, 255, velocitaFade * Time.deltaTime);
    //        fadeColor.a = percent;
    //        fade.SetColor("_Color", fadeColor);
    //    }
    //    sequenza[state].SetActive(false);
    //    state++;
    //    sequenza[state].SetActive(true);
    //}
    void nextState()
    {
        fadeIn = true;
    }


    
}
