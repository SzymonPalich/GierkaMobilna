using UnityEngine;

public class HentaiTentacleMonsterBehavior : MonoBehaviour
{
    public float speed;
    public GameObject bullet;

    private readonly int _rotationModifier = 90;

    private float nextActionTime = 0.0f;
    private readonly float period = 1.0f;

    private void Start()
    {
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Vector3 vectorToTarget = col.transform.position - transform.parent.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - _rotationModifier;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, rotation, Time.deltaTime);

            if (Time.timeSinceLevelLoad > nextActionTime)
            {
                nextActionTime = Time.timeSinceLevelLoad + period;
                Instantiate(bullet, transform.parent.position, transform.parent.rotation);
            }
        }
    }
}
