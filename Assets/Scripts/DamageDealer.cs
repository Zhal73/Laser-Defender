using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    //configuration parameters
    [SerializeField] int damage = 100; //amoujnt of damage per hit


    /*
     * helper method that return the vaue of the variable damage
     */
    public int GetDamage()
    {
        return damage;
    }

    /*
     * helper method that destroys a gameobject whe it is hit
     */
    public void Hit()
    {
        Destroy(gameObject);
    }






}
