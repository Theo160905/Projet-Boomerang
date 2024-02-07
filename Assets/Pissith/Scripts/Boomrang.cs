using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomrang : MonoBehaviour
{
    public Rigidbody p_boomrang;
 
    void Start()
    {
        
    }


    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
           //*Instantiate(p_boomrang);
        }
    }
}
