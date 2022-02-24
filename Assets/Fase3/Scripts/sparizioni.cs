using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparizioni : MonoBehaviour
{
    public List<GameObject> pg;
    private DissolveSphere[] dis;
    private int i=0,j=0;
    public float distance = 20f;
    //public float distanzaMax = 60, d;
    public float velocitaDissolvenza = 4f;

    void Start()
    {

        DissolveSphere[] pgObjects = FindObjectsOfType<DissolveSphere>();
        foreach (var obj in pgObjects)
        {
            pg.Add(obj.gameObject);
            //dis.Add(obj.gameObject.GetComponent<DissolveSphere>());
        }

        dis = new DissolveSphere[pg.Count];
        foreach (GameObject p in pg)
        {
            dis[j++] = p.GetComponent<DissolveSphere>(); 
        }
        j = 0;
        //GetComponent<apparizioni>().startGuidato();
        Debug.Log("CACCHEETTA");
    }



    // Update is called once per frame
    void Update()
    {
        
        /*switch (i) //per i casi in cui far spawnare a canone
        {
            case 0:
                if (dis[j].assolto && distanza(pg[j])<=distance)
                    dissolve(dis[j++]);
                break;

            case 1: //scomparsa girandola
                if (i < pg.Count && distanza(pg[j]) <= distance)
                {
                    dissolve(dis[j++]);
                }
                break;

            case 5: //alberi
                if (i < pg.Count &&
                    (distanza(pg[j]) <= distance || distanza(pg[j + 1]) <= distance || distanza(pg[j + 2]) <= distance))
                {
                    dissolve(dis[j++]);
                    dissolve(dis[j++]);
                    dissolve(dis[j++]);
                }
                break;

            case 6:
                Debug.Log("caso 6");
                if (i < pg.Count && distanza(pg[j]) <= distance)
                {
                    dissolve(dis[j++]);
                }
                break;
            case 7: //scomparsa slide
                if (i < pg.Count && distanza(pg[j]) <= distance)
                {
                    dissolve(dis[j++]);
                }
                break;

            case 9: //cavallucci
                if (i < pg.Count &&
                    (distanza(pg[j]) <= distance || distanza(pg[j + 1]) <= distance || distanza(pg[j + 2]) <= distance))
                {
                    dissolve(dis[j++]);
                    dissolve(dis[j++]);
                    dissolve(dis[j++]);
                }
                break;

            case 10: //cazzafa
                if (i < pg.Count && distanza(pg[j]) <= distance)
                {
                    dissolve(dis[j++]);
                }
                break;

            case 11: //basculant
                if (i < pg.Count && distanza(pg[j]) <= distance)
                {
                    dissolve(dis[j++]);
                }
                break;

            case 13: //streetlamps
                if (i < pg.Count &&
                    (distanza(pg[j]) <= distance || distanza(pg[j + 1]) <= distance || distanza(pg[j + 2]) <= distance))
                {
                    dissolve(dis[j++]);
                    dissolve(dis[j++]);
                }
                break;

            default:
                break;
        }*/
    }

    void dissolve(DissolveSphere go)
    {
        //Debug.Log("dissolvenza");

        go.dissolvenza();
    }

    public void assolve(int i)
    {
        dis[i++].assolvi = true;
    }

    float distanza(GameObject go)
    {
        //Debug.Log("DISTANZA" + Vector3.Distance(go.position, transform.position));
        return Vector3.Distance(go.transform.position, transform.position);
    }
}
