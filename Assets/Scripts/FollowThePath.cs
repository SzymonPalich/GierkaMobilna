using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform waypointStart;

    [SerializeField]
    private Transform waypointEnd;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private bool direction = true;

	// Use this for initialization
	private void Start () {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypointStart.transform.position;
	}
	
	// Update is called once per frame
	private void Update () {
        if (direction)
            Move(waypointEnd);
        else
            Move(waypointStart);
	}

    private void Move(Transform waypoint)
    {
        transform.position = Vector2.MoveTowards(transform.position,
        waypoint.transform.position,
        moveSpeed * Time.deltaTime);

        if (transform.position == waypoint.transform.position)
        {
            direction = !direction;
        } 
    }
}
