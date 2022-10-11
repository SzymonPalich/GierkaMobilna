using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [SerializeField]
    private Transform waypointStart;

    [SerializeField]
    private Transform waypointEnd;

    [SerializeField]
    private float moveSpeed = 2f;

    private bool direction = true;

    protected SpriteRenderer spriteRenderer;

    private void Start()
    {
        transform.position = waypointStart.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (direction)
        {
            Move(waypointEnd);
        }
        else
        {
            Move(waypointStart);
        }
    }

    private void Move(Transform waypoint)
    {
        transform.position = Vector2.MoveTowards(transform.position,
        waypoint.transform.position,
        moveSpeed * Time.deltaTime);

        if (transform.position == waypoint.transform.position)
        {
            spriteRenderer.flipX = direction;
            direction = !direction;
        }
    }
}
