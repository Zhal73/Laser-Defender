using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    /*
     * Helper method that handle the collision 
     * between the Shredder collider and the projectile collider.
     * Once the collision happends it destroyes the object
     * that collides with the Shredder.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);   
    }
}
