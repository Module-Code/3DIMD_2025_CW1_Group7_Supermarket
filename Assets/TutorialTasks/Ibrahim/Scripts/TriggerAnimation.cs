using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour

{


// Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            this.GetComponent<Animator>().Play("animX");
        }
    }


void OnMouseDown()

{

this.GetComponent<Animator>().Play("animX");

} 
}