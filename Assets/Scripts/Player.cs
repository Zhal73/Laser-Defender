using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //configuration parameters
    [SerializeField] float moveSpeed = 10f; //this variable let us set the game speed
    [SerializeField] float padding = 0.5f; //to avoid the Sprite going half out of the screen
    [SerializeField] GameObject playerLaser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.05f;

    //state
    Coroutine firingCoroutine; //variable that hold a reference to the firing Coroutine.

    //variable to set the boudaries of the Player's movement
    float xMin;
    float xMax;
    float yMin;
    float yMax;


   
    

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();      
    }

    /*
     * Helper method that make the Player fire a laser projectile. 
     * The button to fire is the space button, as per Input Fire1 setting.
     * It uses the Coroutine FireContinuously to make the Player 
     * keep firing when the fire button is hold pressed.
     * When the fire button is released the Player stops firing.
     */
    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());              
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    /*
     * Coroutine to make the Player fire continuously.
     * The method uses an infinite loop to instantiate a 
     * new laser GameObject and assigns it a velocity by using 
     * its Rigidbody2D component, then it waits
     * the amount of time set by the variable projectileFiringPeriod. 
     * The velocity given is set by the variable projectileSpeed.
     */
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(playerLaser,
                                          transform.position,
                                               Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
        
    }

    /*
     * Method that make the Player sprite moving.
     * To move the Player object the method reads
     * the values from Input Axes of the project setting.
     * Defaul movement buttons are the arrow keys.
     * Alternative are a, d, w and s keys.
     */
    public void Move()
    {
        //calculates the increment of the x and y position
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; // Time.deltaTime makes the game frame rate indipendent 
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //calculates the new posizion within the boundaries limits
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        //changes the Player's position
        transform.position = new Vector2(newXPos,newYPos);
        
    }

    /*
 * Helper methos that set the limit of the Player's movement.
 * It uses the game Camera method ViewportToWorldPoint()
 * to set these boundaries according to the camera size
 */
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
