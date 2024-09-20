using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with " + collision.collider.name); 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("End of collision " + collision.collider.name);
        //Debug.Break(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("On Trigger Enter"); 
    }
}
