using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    Transform[] players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = (players[0].position + (players[1].position - players[0].position) / 2).x;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
