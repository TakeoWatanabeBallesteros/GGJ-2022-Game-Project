using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingByWaypoints : MonoBehaviour
{
    [SerializeField]
    List<Transform> waypoints;
    [SerializeField]
    float speed;
    [SerializeField]
    float z;
    int order;
    [SerializeField]
    bool started;
    [SerializeField]
    int nextWP;
    // Start is called before the first frame update
    void Start()
    {
        nextWP = 0;
        order = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[nextWP].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[nextWP].position) < z)
            {
                nextWP += order;
                if (nextWP == waypoints.Count || nextWP == -1)
                {
                    order *= -1;
                    nextWP += 2 * order;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            started = true;
        }
    }
}
