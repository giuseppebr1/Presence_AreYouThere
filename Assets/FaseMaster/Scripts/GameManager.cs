using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int state = 0;
    public List<GameObject> sequenza;
    public GameObject visore;
    private Material fade;
    public float velocitaFade = 100f;
    private Vector3 origin;
    float percent = 0f;
    public bool next=false;
    // Start is called before the first frame update
    void Start()
    {
        origin = new Vector3(0f,0f,0f);
        fade = GameObject.Find("FadeSphere").GetComponent<Renderer>().material;
        fade.SetColor("_Color", new Color(255f,255f,255f,0f));
    }

    // Update is called once per frame
    void Update()
    {
        if(next) //debug
        {
            Color fadeColor = fade.GetColor("_Color");
            Debug.Log("colore" + fadeColor);
            percent = 0f;
            while (percent < 255f)
            {
                percent = Mathf.MoveTowards(percent, 255, velocitaFade * Time.deltaTime);
                fadeColor.a = percent;
                fade.SetColor("_Color", fadeColor);
            }
            next = false;
        }    
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

    void fadeOut()
    {
        Debug.Log("fade out");
        while (percent >0f)
        {
            
            Color fadeColor = fade.GetColor("_Color");
            Debug.Log("colore" + fadeColor);
            percent = Mathf.MoveTowards(percent, 0, velocitaFade * Time.deltaTime);
            fadeColor.a = percent;
            fade.SetColor("_Color", fadeColor);
        }
    }

    void nextState()
    {
        Debug.Log("fade in");
        Color fadeColor = fade.GetColor("_Color");
        percent = 0f;
        while (percent < 255f)
        {
            percent = Mathf.MoveTowards(percent, 255, velocitaFade * Time.deltaTime);
            fadeColor.a = percent;
            fade.SetColor("_Color", fadeColor);
        }
        sequenza[state].SetActive(false);
        state++;
        sequenza[state].SetActive(true);
        if (state > 3)
            whiteAction();
        else
            fadeOut();
    }

    void whiteAction()
    {
        //todo palletta
        fadeOut();
    }

    
}
