using UnityEngine;

public class TriggerGreet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnMouseDown()
    {
        this.GetComponent<Animator>().Play("Greet");
    }
}
