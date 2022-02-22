using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeDissolve : MonoBehaviour
{
    Material materials;
    public float fade;
    // Start is called before the first frame update
    void Start()
    {
        materials = GetComponent<MeshRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        materials.SetFloat("_Fade", fade);

        if (Input.GetKeyDown(KeyCode.L))
        {
            
            materials.SetFloat("_Fade", 1);
            Debug.Log(materials.GetFloat("_Fade"));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            materials.SetFloat("_Fade", -1);
            Debug.Log(materials.GetFloat("_Fade"));
        }
    }
}
