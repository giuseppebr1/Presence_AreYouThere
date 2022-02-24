using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDuration : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 5f;

    void OnEnable()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(duration);
        GameObject.Find("GameManager").GetComponent<GameManager>().fadeIn = true;
    }
}
