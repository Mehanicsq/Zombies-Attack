using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{

    public float timelife;


    void Update()
    {
        timelife += Time.deltaTime;
        if (timelife > 2) 
        { 
            Destroy(this.gameObject);
        }
        
    }
}
