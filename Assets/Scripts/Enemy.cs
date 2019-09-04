using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //configuration paramenters
    [SerializeField] float health = 100;    //total health of an enemy object
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3.0f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float enemyLaserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);   
    }

    // Update is called once per frame
    void Update()
    {
        CountdownAndShoot();  
    }

    /*
     * helper method that allows the enemy object
     * to shoot. It decreases the variable shotCounter
     * and when it reaches zero the enemy fires
     */
    private void CountdownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    /*
     * helper method to create a enemy projectile
     * object to be fired. It instantiate a new GameObject
     * and give it a velocity equal to the variable
     * enemyLaserSpeed.
     */
    private void Fire()
    {
        GameObject enemyFire = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        enemyFire.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
    }


    /*
     * helper method that reduces the health of a gameobject
     * when a collision is detected.
     * When the health is less or equal than zero
     * it destroys the object
     */

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
