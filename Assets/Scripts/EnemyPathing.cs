using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //Configuration parameter
    
    WaveConfig waveConfig;
    
     //list of waypoints followed by the enemy ships
    List<Transform> waypoints;

    //variable that count the waypoint reached throught the path.
    int waypointIndex = 0;
              
    // Start is called before the first frame update
    void Start()
    {
        //get the waypoints of the first wave
        waypoints = waveConfig.GetWayPoints();
        //put the enemy on the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /*
     * helper method to set the vatiable waveCongig
     */
     public void SetWaveConfig(WaveConfig waveConfig)
     {
        this.waveConfig = waveConfig;  
     }


    /*
     * Helper method that make the enemy move.
     * It goes through the waypoint list and uses the
     * Vector2.MoveToward method to make the actual movement.
     * When the last waypoint is reached, the gameObject
     * is destroied.
     */
    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            //destinaton waypoint
            var targetPosition = waypoints[waypointIndex].transform.position;
            //distance delta
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            //actual movement
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //when the enemy reaches the waypoint, it aims to the following one
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //when the enemy reache s the lasg waypoint, it destroyes itself
        else
        {
            Destroy(gameObject);
        }
    }
}
